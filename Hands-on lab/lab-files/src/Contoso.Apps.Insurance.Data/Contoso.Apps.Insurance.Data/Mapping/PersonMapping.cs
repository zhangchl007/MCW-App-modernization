namespace Contoso.Apps.Insurance.Data.Mapping
{
    public static class PersonMapping
    {
        public static DTOs.Person MapEntityToDto(Person source)
        {
            var destination = new DTOs.Person
            {
                Id = source.Id,
                Address = source.Address,
                Address2 = source.Address2,
                City = source.City,
                Dob = source.Dob,
                FName = source.FName,
                LName = source.LName,
                Postcode = source.Postcode,
                Suburb = source.Suburb,
                DisplayName = $"{source.LName}, {source.FName} of {source.City}, {source.Suburb}"
            };

            return destination;
        }

        public static Data.Person MapDtoToEntity(DTOs.Person source)
        {
            var destination = new Data.Person
            {
                Id = source.Id,
                Address = source.Address,
                Address2 = source.Address2,
                City = source.City,
                Dob = source.Dob,
                FName = source.FName,
                LName = source.LName,
                Postcode = source.Postcode,
                Suburb = source.Suburb
            };

            return destination;
        }

        /// <summary>
        /// Copies properties from the source to the destination object in order to
        /// save the source object's values to the database.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public static void CopyPropertiesForUpdate(Person source, ref Person destination)
        {
            destination.Address = source.Address;
            destination.Address2 = source.Address2;
            destination.City = source.City;
            destination.Dob = source.Dob;
            destination.FName = source.FName;
            destination.LName = source.LName;
            destination.Postcode = source.Postcode;
            destination.Suburb = source.Suburb;
        }
    }
}
