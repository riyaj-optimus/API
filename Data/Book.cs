﻿namespace DbOperationWithEfCode.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? NoOfPages { get; set; }
        public bool IsActive { get; set; }
        //we need to tell th EFCore that we will use this class in our DB
        //for this - we have to define some things in teh DBContext class

        public DateTime? CreatedOn { get; set; }

        public int? LanguageId { get; set; }
        //this col will act as a foreign key with the language table
        public int? AuthorId { get; set; }

        public ICollection<BookPrice>? BookPrices { get; set; }
        public Language? Language { get; set; }//if we comment this ot , we can never work with fluent API
        //created  to give reference to the LangId col (of Books table ) : Language table
        public Author? Author { get; set; }
        public string? country {  get; set; }
    }
}
