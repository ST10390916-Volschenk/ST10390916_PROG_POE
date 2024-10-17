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

        public string SubmitClaim(Claim claim)
        {
            AppDbContext context = new AppDbContext();
            context.claims.Add(claim);
            context.SaveChanges();

            return "Claim submitted.";
        }

        public List<Claim> GetClaimsByUserID(int userID)
        {
            AppDbContext context = new AppDbContext();
            List<Claim> claims = context.claims.Where(c => c.UserID == userID).ToList();
            return claims;
        }

        public List<Claim> GetPendingClaims()
        {
            AppDbContext context = new AppDbContext();
            List<Claim> claims = context.claims.Where(c => c.Status == ClaimStatus.Pending).ToList();
            return claims;
        }

        public void UpdateClaim(int claimID, ClaimStatus status)
        {
            AppDbContext context = new AppDbContext();
            context.claims.Find(claimID).Status = status;
            context.SaveChanges();
        }

    }

    public enum ClaimStatus
    {
        Pending,
        Approved,
        Rejected
    }



}
