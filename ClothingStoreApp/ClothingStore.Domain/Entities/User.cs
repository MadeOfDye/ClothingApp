namespace ClothingStore.Domain.Entities
{
    // TODO: Implement The Logged-In User class according to the domain requirements after current vertical slice.
    public class User
    {
        public Guid UserId { get; private set; }
        public string Username { get; private set; }
        public ShoppingCart ShoppingCart { get; private set; }

        protected User() { }
         public User(string username) { 
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be null or empty", nameof(username));
            UserId = Guid.NewGuid();
            Username = username;
            ShoppingCart = new ShoppingCart(UserId);
        }
        public void AddToCart(Item item)
        {
            if(ShoppingCart == null)
                throw new InvalidOperationException("User does not have a shopping cart.");
            if (item == null) throw new ArgumentNullException(nameof(Item), "Item cannot be null");
            ShoppingCart.AddItem(item, 1);
        }

        public void RemoveFromCart(Guid itemId)
        {
            if(itemId == Guid.Empty)
                throw new ArgumentNullException(nameof(itemId), "Item ID cannot be null or empty");
            Item item = ShoppingCart.Items.FirstOrDefault(i => i.Item.ItemId == itemId)?.Item ?? throw new InvalidOperationException("Item not found in the shopping cart.");
            //if (item == null)
            //    throw new InvalidOperationException("Item not found in the shopping cart.");
            ShoppingCart.RemoveItem(item);
        }

        // Elements for a future logged-in user. Currently this is a Guest User and enough for the current vertical slice.
        //public string Email { get; private set; }
        //public DateTimeOffset CreatedAt { get; private set; }
        //protected User() { }
        //public User(string username, string email)
        //{
        //    if (string.IsNullOrWhiteSpace(username))
        //        throw new ArgumentException("Username cannot be null or empty", nameof(username));
        //    if (string.IsNullOrWhiteSpace(email))
        //        throw new ArgumentException("Email cannot be null or empty", nameof(email));
        //    UserId = Guid.NewGuid();
        //    Username = username;
        //    Email = email;
        //    CreatedAt = DateTime.UtcNow;
        //}
        //public void UpdateEmail(string email)
        //{
        //    if (string.IsNullOrWhiteSpace(email))
        //        throw new ArgumentException("Email cannot be null or empty", nameof(email));
        //    Email = email;
        //}
    }
}
