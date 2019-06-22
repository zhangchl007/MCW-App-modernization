using System.Collections.Generic;
using System.Linq;
using Contoso.Apps.Insurance.Data;
using Contoso.Apps.Insurance.Data.Logic;
using Contoso.Apps.Insurance.Data.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace Contoso.Apps.Insurance.WebAPI.Controllers
{
    [ApiController]
    [Route("api/people")]
    public class PeopleController : ControllerBase
    {
        private readonly string _connectionString = EncryptionHelper.SecretConnectionString;

        /// <summary>
        /// Deletes a person
        /// </summary>
        /// <param name="personId"></param>
        [HttpDelete("{id:int}")]
        public void DeletePerson(int personId)
        {
            using (var actions = new PersonActions(_connectionString))
            {
                actions.DeletePerson(personId);
            }
        }

        /// <summary>
        /// Gets all people.
        /// </summary>
        /// <param name="getPeopleWhoAreNotPolicyHolders"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IList<Data.DTOs.Person>> GetAllPeople(bool getPeopleWhoAreNotPolicyHolders = false)
        {
            List<Data.DTOs.Person> people;

            using (var actions = new PersonActions(_connectionString))
            {
                people = getPeopleWhoAreNotPolicyHolders ? actions.GetPeopleWhoAreNotPolicyHolders().Select(PersonMapping.MapEntityToDto).ToList() : actions.GetAllPeople().ToList().Select(PersonMapping.MapEntityToDto).ToList();
            }

            return people;
        }

        /// <summary>
        /// Gets a person.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public ActionResult<Data.DTOs.Person> GetPerson(int id)
        {
            Data.DTOs.Person person;

            using (var ctx = new ContosoInsuranceContext(_connectionString))
            {
                person = PersonMapping.MapEntityToDto(ctx.People.FirstOrDefault(p => p.Id == id));
            }

            return person;
        }

        /// <summary>
        /// Saves a new person.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<int> SavePerson(Data.DTOs.Person person)
        {
            using (var actions = new PersonActions(_connectionString))
            {
                var personModel = PersonMapping.MapDtoToEntity(person);
                actions.SavePerson(personModel);
                person.Id = personModel.Id;
            }
            return person.Id;
        }
    }
}