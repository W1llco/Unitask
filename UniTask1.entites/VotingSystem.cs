using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniTask.entites
{
    public class VotingSystem
    {
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }

        //public Task<Party> GetWinnerFirstPTP(List<Candidate> candidates)
        //{
        //    var ConservativeWins = 0;
        //    var LabourWins = 0;

        //    var ConservativeId = new Guid();
        //    var LabourId = new Guid();

        //    Guid ScotlandId = new Guid();
        //    var ScotlandCadidates = candidates.Where(x => x.RegionID == ScotlandId);
        //    var ScotlandWinnerCadidate = ScotlandCadidates.OrderByDescending(x => x.VoteCount).First();

        //    Guid WalesId = new Guid();
        //    var WalesCadidates = candidates.Where(x => x.RegionID == WalesId);
        //    var WalesWinnerCadidate = WalesCadidates.OrderByDescending(x => x.VoteCount).First();

        //    Guid EnglandId = new Guid();
        //    var EnglandCadidates = candidates.Where(x => x.RegionID == EnglandId);
        //    var EnglandWinnerCadidate = EnglandCadidates.OrderByDescending(x => x.VoteCount).First();

        //  if (ScotlandWinnerCadidate.PartyID == ConservativeId)
        //  {
        //        ConservativeWins++;
        //  }
        //  else
        //  {
        //        LabourWins++;
        //  }
        //  if (WalesWinnerCadidate.PartyID == ConservativeId)
        //  {
        //        ConservativeWins++;
        //  }
        //  else
        //  {
        //        LabourWins++;
        //  }
        //  if (EnglandWinnerCadidate.PartyID == ConservativeId)
        //  {
        //        ConservativeWins++;
        //  }
        //  else
        //  {
        //        LabourWins++;
        //  }

        //    //return ConservativeWins < LabourWins ? "labour" : "Conservaties";

        //}
    }
}
