using System.ComponentModel.DataAnnotations;

namespace RestApi.Data.DTO
{
    public class userDto
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string fullname { get; set; }
        public bool isActive { get; set; }
    }
}
