﻿namespace BookTrackingApi.DTOs.Author
{
    public class UpdateAuthorDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public int NationalityId { get; set; }
    }
}
