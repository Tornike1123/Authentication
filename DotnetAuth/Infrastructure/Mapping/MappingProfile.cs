using AutoMapper;
using DotnetAuth.Domain.Contracts;
using DotnetAuth.Domain.Entities;

namespace DotnetAuth.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ApplicationUser, UserResponse>();//ApplicationUser კლასის ობიექტის მონაცემები გადაიყვანება UserResponse ტიპის ობიექტში.
        CreateMap<ApplicationUser, CurrentUserResponse>();//ApplicationUser მონაცემები გადაკეთდება CurrentUserResponse ტიპად.
        CreateMap<ApplicationUser, UserRegisterRequest>();//ApplicationUser გადაიყვანება UserRegisterRequest ტიპის ობიექტში.
    }
}

// AutoMapper:
//  ეს არის ბიბლიოთეკა, რომელიც გამოიყენება იმისთვის, რომ ერთ ტიპის ობიექტის მონაცემები მეორეში მარტივად გადაიყვანოს.
//  მაგალითად, შეიძლება Domain Entity-ს ობიექტი (რომელიც მონაცემთა ბაზის მოდელია) გადაიყვანოთ DTO (Data Transfer Object)-ში, რომელსაც API იყენებს მონაცემების დაბრუნებისთვის.
//  ეს ხდება CreateMap<Source, Destination>() მეთოდით, სადაც:
//  Source – არის საწყისი ობიექტის ტიპი (მაგ. ApplicationUser).
//  Destination – არის მიზანი ობიექტის ტიპი (მაგ. UserResponse).