using DotnetAuth.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotnetAuth.Infrastructure.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}

//ეს კოდი აღწერს ApplicationDbContext კლასს, რომელიც არის Entity Framework Core-ის კონტექსტი. ამ კლასს იყენებენ მონაცემთა ბაზასთან კავშირის
//დასამყარებლად და მასში სხვადასხვა ცხრილების (Entities) განსაზღვრისთვის.
//ApplicationDbContext მემკვიდრეობით იღებს IdentityDbContext-ს, რომელიც არის ASP.NET Identity-ის სპეციალური DbContext.

// კონსტრუქტორი იღებს DbContextOptions<ApplicationDbContext> პარამეტრს, რომელიც გამოიყენება ApplicationDbContext-ის
// კონფიგურაციისთვის (მაგ., რომელ მონაცემთა ბაზასთან უნდა იყოს დაკავშირებული, კავშირის სტრინგი და სხვა).
// ამ კონსტრუქტორს გადაეცემა ეს პარამეტრი IdentityDbContext-ის ბაზის კონსტრუქტორს.

// base.OnModelCreating(builder) გამოძახება აუცილებელია, რომ Identity-ის მიერ განსაზღვრული ცხრილები და კონფიგურაციები ავტომატურად შეიქმნას.


//STEP 6