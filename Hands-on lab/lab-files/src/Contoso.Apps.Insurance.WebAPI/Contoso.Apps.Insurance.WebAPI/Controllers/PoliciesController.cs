using System.Collections.Generic;
using System.Linq;
using Contoso.Apps.Insurance.Data;
using Contoso.Apps.Insurance.Data.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Apps.Insurance.WebAPI.Controllers
{
    [ApiController]
    [Route("api/policies")]
    public class PoliciesController : ControllerBase
    {
        private readonly string _connectionString = EncryptionHelper.SecretConnectionString;

        /// <summary>
        /// Gets all policies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IList<Data.DTOs.Policy>> GetPolicies()
        {
            List<Data.DTOs.Policy> policies;

            using (var ctx = new ContosoInsuranceContext(_connectionString))
            {
                policies = ctx
                    .Policies
                    .Include(c => c.PolicyHolders)
                    .ToList()
                    .Select(PolicyMapping.MapEntityToDto)
                    .ToList();
            }

            return policies;
        }

        /// <summary>
        /// Gets a policy
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public ActionResult<Data.DTOs.Policy> GetPolicy(int id)
        {
            Data.DTOs.Policy policy;

            using (var ctx = new ContosoInsuranceContext(_connectionString))
            {
                var result = ctx
                    .Policies
                    .Include(c => c.PolicyHolders)
                    .FirstOrDefault(p => p.Id == id);

                policy = PolicyMapping.MapEntityToDto(result);
            }

            return policy;
        }
    }
}