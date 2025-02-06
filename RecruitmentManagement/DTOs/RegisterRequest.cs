public class RegisterRequest
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public DateOnly BirthDate { get; set; }
            public string? Phone { get; set; }
            public int RoleId { get; set; }
        }