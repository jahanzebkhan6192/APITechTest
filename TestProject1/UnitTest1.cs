using DataManager.Model;
using DataManger;

namespace TestProject1
{
    public class UnitTest1
    {
        IDataRepository _db = new DataRepository();

        [Fact]
        public void CompanyClaims_Returns_1_claims_for_CompanyID_1()
        {
            Assert.Equal(1, _db.CompanyClaims(1).Count);
        }

        [Fact]
        public void TestUpdateClaimDataName()
        {
            Claim claim = new Claim() { UCR = "UCR1", AssuredName = "updated" };            
                       
            Assert.True(_db.UpdateCompanyClaimsDetails(claim));

        }
         
        //Could do with testing claim days 
        //CompanyClaimsDetails
    }
}