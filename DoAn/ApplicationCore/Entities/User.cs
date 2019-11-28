using ApplicationCore.Interfaces;
namespace ApplicationCore.Entities
{
    public class User : IAggregateRoot
    {
        public string UserId {get; set;}
        public string UserName { get; set; }  
   
        public string PassWord { get; set; }  
        public User(){}
    }
}