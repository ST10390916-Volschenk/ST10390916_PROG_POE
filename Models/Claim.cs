//ST10390916
//All work is my own unless otherwise cited or referenced.

using ST10390916_PROG_POE.Data;

namespace ST10390916_PROG_POE.Models
{
    public class Claim
    {
        public int ClaimID { get; set; }
        public int UserID { get; set; }
        public string ClaimTitle { get; set; }
        public int HoursWorked { get; set; }
        public double RatePerHour { get; set; }
        public ClaimStatus Status { get; set; }
        public DateOnly ClaimDate { get; set; }

        /// <summary>
        /// Adds a new claim to the database
        /// </summary>
        /// <param name="claim"></param>
        public string SubmitClaim(Claim claim)
        {
            string msg = "";
            if (claim != null)
            {
                AppDbContext context = new AppDbContext();
                context.claims.Add(claim);
                context.SaveChanges();
                msg = "Claim submitted.";
            }
            else
            {
                msg = "Provide a valid claim";
            }


            return msg;
        }

        /// <summary>
        /// Searches for claims by user ID
        /// </summary>
        /// <param name="userID"></param>
        public List<Claim> GetClaimsByUserID(int userID)
        {
            AppDbContext context = new AppDbContext();
            List<Claim> claims = context.claims.Where(c => c.UserID == userID).ToList();
            return claims;
        }

        /// <summary>
        /// Searches for pending claims
        /// </summary>
        public List<Claim> GetPendingClaims()
        {
            AppDbContext context = new AppDbContext();
            List<Claim> claims = context.claims.Where(c => c.Status == ClaimStatus.Pending).ToList();
            return claims;
        }

        /// <summary>
        /// Updates the status of a claim
        /// </summary>
        /// <param name="claimID"></param>
        /// <param name="status"></param>
        public bool UpdateClaim(int claimID, ClaimStatus status)
        {
            bool result = false;

            AppDbContext context = new AppDbContext();

            Claim? claim = context.claims.Find(claimID);
            if (claim != null)
            {
                claim.Status = status;
                context.SaveChanges();
                result = true;
            }

            return result;
        }

    }

    public enum ClaimStatus
    {
        Pending,
        Approved,
        Rejected
    }



}
