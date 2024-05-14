namespace Model
{
    public class Book
    {


        public Book() {
            //BookId = nextId;
            //nextId++;
        }
        private static int nextId = 1;

        public int BookId { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public string PublishingHouse { get; set; }
        public uint Quantity { get; set; }

    }
}
