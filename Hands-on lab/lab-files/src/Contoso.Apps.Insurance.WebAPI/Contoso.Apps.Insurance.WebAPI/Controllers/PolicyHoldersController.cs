using System.Collections.Generic;
using System.Linq;
using Contoso.Apps.Insurance.Data;
using Contoso.Apps.Insurance.Data.Logic;
using Contoso.Apps.Insurance.Data.Mapping;
using Contoso.Apps.Insurance.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Apps.Insurance.WebAPI.Controllers
{
    [ApiController]
    [Route("api/policyholders")]
    public class PolicyHoldersController : ControllerBase
    {
        private readonly string _connectionString = EncryptionHelper.SecretConnectionString;

        /// <summary>
        /// Deletes a policy holder.
        /// </summary>
        /// <param name="policyHolderId"></param>
        [HttpDelete("{id:int}")]
        public void DeletePolicyHolder(int policyHolderId)
        {
            using (var actions = new PolicyActions(_connectionString))
            {
                actions.DeletePolicyHolder(policyHolderId);
            }
        }

        /// <summary>
        /// Gets a policy holder.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public ActionResult<Data.DTOs.PolicyHolder> GetPolicyHolder(int id)
        {
            Data.DTOs.PolicyHolder policyHolder;

            using (var ctx = new ContosoInsuranceContext(_connectionString))
            {
                var policyHolderData = ctx.PolicyHolders
                    .Include(p => p.Policy)
                    .Include(p => p.Person)
                    .Include(p => p.Dependents)
                    .FirstOrDefault(p => p.Id == id);

                policyHolder = PolicyHolderMapping.MapEntityToDto(policyHolderData);
            }

            return policyHolder;
        }

        /// <summary>
        /// Gets all policy holders.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IList<PolicyHolderViewModel>> GetPolicyHolders()
        {
            List<PolicyHolderViewModel> policies;

            using (var ctx = new ContosoInsuranceContext(_connectionString))
            {
                var policyHolders = ctx.PolicyHolders
                    .Include(p => p.Policy)
                    .Include(p => p.Person)
                    .Include(p => p.Dependents)
                    .OrderBy(p => p.Person.LName)
                    .ToList();

                policies = policyHolders.Select(PolicyHolderMapping.MapEntityToViewModel).ToList();
            }

            return policies;
        }

        /// <summary>
        /// Saves a new policy holder.
        /// </summary>
        /// <param name="policyHolder"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<int> SavePolicyHolder([FromBody]Data.DTOs.PolicyHolder policyHolder)
        {
            using (var actions = new PolicyActions(_connectionString))
            {
                var policyHolderModel = PolicyHolderMapping.MapDtoToEntity(policyHolder);
                actions.SavePolicyHolder(policyHolderModel);
                policyHolder.Id = policyHolderModel.Id;
            }

            return policyHolder.Id;
        }
    }
}