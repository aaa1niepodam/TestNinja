namespace TestNinja.Fundamentals
{
    public class Reservation
    {
        public User MadeBy { get; set; }

        //three scenarios (execution paths)
        public bool CanBeCancelledBy(User user) => (user.IsAdmin || MadeBy == user);
    }

    public class User
    {
        public bool IsAdmin { get; set; }
    }
}