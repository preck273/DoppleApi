using DoppleApi.Entities;
using DoppleApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
namespace DoppleApi.Controllers
{
   
    public class TestResultController : Controller
    {

        private readonly bs39hu6mp56dbv0qContext DoppleDB;
        public TestResultController(bs39hu6mp56dbv0qContext bs39hu6mp56dbv0qContext)
        {
            this.DoppleDB = bs39hu6mp56dbv0qContext;
        }
        // get test result by id in either XML or  JSON format
        [HttpGet("GetTestResultById.{format}"), FormatFilter]
        public async Task<ActionResult<TestResultModel>> GetInstructionById(int Id)
        {
            TestResultModel TestResult = await DoppleDB.Testresults.Select(s => new TestResultModel
            {

                TestId = s.TestId,
                Result = s.Result,
                Reason = s.Reason,
                OperatorCompanyId = s.OperatorCompanyId,

            }).FirstOrDefaultAsync(s => s.TestId == Id);
            if (TestResult == null)
            {
                return null;
            }
            else
            {
                return TestResult;

            }
        }
        // insert test result by id in either XML or  JSON format
        [HttpPost("InsertTestResult.{format}"), FormatFilter]
        public async Task<HttpStatusCode> InsertUser(TestResultModel TestResult)
        {


            
            Test test = DoppleDB.Tests.FirstOrDefault(s => s.TestId == TestResult.TestId);
            Operator opr = DoppleDB.Operators.FirstOrDefault(s => s.OperatorId == TestResult.OperatorCompanyId);
            var entity = new Testresult()
            {
                TestId = test.TestId,
                Result = TestResult.Result,
                Reason = TestResult.Reason,
                OperatorCompanyId = opr.OperatorId,
            };

            DoppleDB.Testresults.Add(entity);

            await DoppleDB.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        // delete test result by id and operatorID in either XML or  JSON format
        [HttpDelete("DeleteTestResult/{Id}.{format}"), FormatFilter]
        public async Task<HttpStatusCode> DeleteUser(int Id, String operatorId) 
        {/// <summary>
///  This class performs an important function.
/// </summary>
            var entity = new Testresult()
            {
                TestId = Id,
                /// <summary>
                ///  This class performs an important function.
                /// </summary>
                OperatorCompanyId = operatorId,
            };
            /// <summary>
            ///  This class performs an important function.
            /// </summary>
            DoppleDB.Testresults.Attach(entity);
            DoppleDB.Testresults.Remove(entity);
            await DoppleDB.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        // update etst result by id in either XML or  JSON format
        [HttpPut("UpdateTestResultById.{format}"), FormatFilter]
        public async Task<HttpStatusCode> UpdateUser(TestResultModel TestResult)
        {
            var entity = await DoppleDB.Testresults.FirstOrDefaultAsync(s => s.TestId == TestResult.TestId && s.OperatorCompanyId == TestResult.OperatorCompanyId);
            entity.TestId = TestResult.TestId;
            entity.Result = TestResult.Result;
            entity.Reason = TestResult.Reason;
            entity.OperatorCompanyId = TestResult.OperatorCompanyId;
            await DoppleDB.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

    }
}


