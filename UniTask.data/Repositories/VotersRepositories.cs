using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UniTask.entites;

namespace UniTask.data.Repositories
{
    // Class to handle database operations for Voter entities.
    public class VotersRepositories
    {
        // Database context for Voter data access.
        private readonly VotingContext _context;

        // Constructor with dependency injection for the database context.
        public VotersRepositories(VotingContext context)
        {
            _context = context;
        }

        // Find a voter by their unique verification code.
        public Voter FindByVerificationCode(string verificationCode)
        {
            return _context.Voters.FirstOrDefault(v => v.VerifcationCode == verificationCode);
        }

        // Find voters by name, case-insensitive comparison.
        public IEnumerable<Voter> FindByName(string Name)
        {
            return _context.Voters.Where(v => v.Name.ToLower() == Name.ToLower());
        }

        // Find voters by email address.
        public IEnumerable<Voter> FindByEmail(string Email)
        {
            return _context.Voters.Where(v => v.Email == Email);
        }

        // Confirm voter login for external authentication.
        public Voter ConfirmVoterLogin(Voter voter)
        {
            return _context.Voters.FirstOrDefault(x => x.Name == voter.Name && x.Password == voter.Password && x.DateOfBirth.Date == voter.DateOfBirth.Date && x.VerifcationCode == voter.VerifcationCode);
        }

        // Confirm voter login for internal uses, verifying their identity is validated.
        public Voter ConfirmInternalVoterLogin(Voter voter)
        {
            return _context.Voters.FirstOrDefault(x => x.Name == voter.Name && x.VerifcationCode == voter.VerifcationCode && x.IsVerified == voter.IsVerified);
        }

        // Load a single voter by their ID.
        public Voter Load(Guid id)
        {
            if (id == Guid.Empty)
                return null;
            return _context.Voters.Local.First(x => x.ID == id);
        }

        // Load all voters.
        public IEnumerable<Voter> LoadAll()
        {
            return _context.Voters.Local.AsEnumerable();
        }

        // Save a new or existing voter to the database.
        public Voter Save(Voter entity)
        {
            if (entity.ID == Guid.Empty)
            {
                entity.ID = Guid.NewGuid(); // Assign a new unique ID.
                entity.UserID = Guid.NewGuid(); // Ensure the user has a unique user ID.
                entity.VerifcationCode = GenerateVerificationCode(); // Generate a new verification code.

                var passwordResult = GeneratePassword(); // Generate a secure password.
                entity.Password = passwordResult.HashedPassword;
                entity.Salt = passwordResult.Salt;

                Insert(entity);
                return entity;
            }
            Update(entity);
            return entity;
        }

        // Insert a new voter record into the database.
        private void Insert(Voter entity)
        {
            _context.Voters.Add(entity);
            _context.SaveChanges();
        }

        // Generate a secure password for a new or updating voter.
        private (string HashedPassword, string Salt) GeneratePassword()
        {
            // Generate a random password of a desired length
            string password = GenerateRandomPassword(12);
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return (hashedPassword, Convert.ToBase64String(salt));
        }

        // Generate a random password.
        private string GenerateRandomPassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }

            return res.ToString();
        }

        // Generate a random password.
        private string GenerateVerificationCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        // Delete an existing voter from the database.
        public void Delete(Voter entity)
        {
            if (entity.ID != Guid.Empty)
            {
                _context.Remove(entity);
                _context.SaveChanges();
            }
        }


        // Update existing voter details in the database.
        public void Update(Voter entity)
        {
            var voter = _context.Voters.FirstOrDefault(x => x.ID == entity.ID);
            voter.UserID = entity.UserID;
            voter.Password = entity.Password;
            voter.VerifcationCode = entity.VerifcationCode;
            voter.IsVerified = entity.IsVerified;
            voter.HasVoted = entity.HasVoted;
            voter.RegionID = entity.RegionID;
            voter.DateOfBirth = entity.DateOfBirth;
            voter.Name = entity.Name;
            _context.SaveChanges();
        }
    }
}
