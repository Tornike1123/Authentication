1.შევქმნათ ფოლდერები: "Controllers","Domain","Exceptions","Infrastructure","Service","Entities(ბაზა)"
2.Nuget: 
         1.AutoMapper,
         2.Microsoft.AspNetCore.Authentication.JwtBearer
         3.Microsoft.AspNetCore.Identity.EntityFrameworkCore
         4.Microsoft.EntityFrameworkCore.SqlServer
         5.Microsoft.EntityFrameworkCore.Tools
         6.Microsoft.EntityFrameworkCore.Designe

------------------------------------------------------

1. AutoMapper
   ობიექტების ავტომატური მიგრაციისთვის.
   👉 გამოიყენება მონაცემთა მოდელების გადაყვანისთვის სხვა ობიექტის ტიპში (მაგალითად, მონაცემთა ბაზის მოდელიდან DTO-ში).
   მაგალითი:
   DB მოდელი → API მოდელი (DTO).

2. Microsoft.AspNetCore.Authentication.JwtBearer
      JWT (JSON Web Token) ავტენტიფიკაციის მხარდასაჭერად.
      👉 გამოიყენება API-სთვის, სადაც მომხმარებლის ავტორიზაციისთვის JWT ტოკენები გამოიყენება.
      როლები:
             მომხმარებლის ავტორიზაცია.
             უსაფრთხოების უზრუნველსაყოფად.

3. Microsoft.AspNetCore.Identity.EntityFrameworkCore
      ASP.NET Identity-ის მხარდაჭერა Entity Framework Core-თან ერთად.
      👉 გამოიყენება მომხმარებლის იდენტიფიკაციისთვის (როლები, პაროლები, ავტორიზაცია).
      ფუნქციები:
                მომხმარებლის რეგისტრაცია და ავტორიზაცია.
                როლების მართვა.

4. Microsoft.EntityFrameworkCore.SqlServer
      Entity Framework Core მხარდაჭერა SQL Server-ისთვის.
      👉 გამოიყენება, თუ მონაცემთა ბაზად იყენებთ Microsoft SQL Server-ს.
      ფუნქციები:
                მონაცემთა ბაზასთან ურთიერთქმედება.
                SQL ოპერაციები EF Core API-თი.

5. Microsoft.EntityFrameworkCore.Tools
      ინსტრუმენტები EF Core-ის მიგრაციებისთვის.
      👉 გამოიყენება მიგრაციების შექმნისა და მართვისთვის.
      ფუნქციები:
                dotnet ef ბრძანებების გაშვება (მაგ., მიგრაციების დამატება, ბაზის განახლება).

6. Microsoft.EntityFrameworkCore.Design
   EF Core დიზაინის დროზე საჭირო ბიბლიოთეკა.
   👉 გამოიყენება მიგრაციების გენერირებისთვის და სხვა დიზაინის დროის ოპერაციებისთვის.
   ფუნქციები:
             მიგრაციების შექმნა.
             კოდით მონაცემთა ბაზის მოდელირება.
