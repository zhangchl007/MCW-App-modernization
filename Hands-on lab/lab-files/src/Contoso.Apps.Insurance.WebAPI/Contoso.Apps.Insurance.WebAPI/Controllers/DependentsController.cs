using System.Collections.Generic;
using System.Linq;
using Contoso.Apps.Insurance.Data;
using Contoso.Apps.Insurance.Data.Logic;
using Contoso.Apps.Insurance.Data.Mapping;
using Microsoft.AspNetCore.Mvc;
using Dependent = Contoso.Apps.Insurance.Data.DTOs.Dependent;

namespace Contoso.Apps.Insurance.WebAPI.Controllers
{
    [ApiController]
    [Route("api/dependents")]
    public class DependentsController : ControllerBase
    {
        private readonly string _connectionString = EncryptionHelper.SecretConnectionString;

        /// <summary>
        /// Deletes a dependent.
        /// </summary>
        /// <param name="dependentId"></param>
        [HttpDelete("{id:int}")]
        public void DeleteDependent(int dependentId)
        {
            using (var actions = new DependentActions(_connectionString))
            {
                actions.DeleteDependent(dependentId);
            }
        }

        /// <summary>
        /// Gets a dependent
        /// </summary>
        /// <param name="id">Dependent id</param>
        /// <returns>Dependent information</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Not Found</response>
        [HttpGet("{id:int}")]
        public ActionResult<Dependent> GetDependent(int id)
        {
            Dependent dependent;
            // TODO: Review
            using (var ctx = new ContosoInsuranceContext(_connectionString))
            {
                dependent = DependentMapping.MapEntityToDto(ctx.Dependents.FirstOrDefault(p => p.Id == id));
            }

            return dependent;
        }

        /// <summary>
        /// Gets dependents by policy holder.
        /// </summary>
        /// <param name="policyHolderId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IList<Dependent>> GetDependentsByPolicyHolder(int policyHolderId)
        {
            List<Dependent> dependents;

            using (var actions = new DependentActions(_connectionString))
            {
                dependents = actions.GetDependentsByPolicyHolder(policyHolderId).Select(DependentMapping.MapEntityToDto).ToList();
            }

            return dependents;
        }

        /// <summary>
        /// Saves a new dependent.
        /// </summary>
        /// <param name="dependent"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<int> SaveDependent(Dependent dependent)
        {
            using (var actions = new DependentActions(_connectionString))
            {
                var dependentModel = DependentMapping.MapDtoToEntity(dependent);
                actions.SaveDependent(dependentModel);
                dependent.Id = dependentModel.Id;
            }
            return dependent.Id;
        }
    }
}