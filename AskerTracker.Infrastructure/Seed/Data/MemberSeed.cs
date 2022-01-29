using System;
using System.Collections.Generic;
using AskerTracker.Domain;
using AskerTracker.Domain.Entities;
using AskerTracker.Domain.Types;
using AskerTracker.Infrastructure.Extensions;
using Bogus;

namespace AskerTracker.Infrastructure.Seed.Data;

public static class MemberSeed
{
    private static Guid _startId = new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3310");

    public static List<Member> FakeMembers()
    {
        var membersFaker = new Faker<Member>()
            .RuleFor(member => member.Id, f => _startId = _startId.Increment())
            .RuleFor(member => member.Active, f => f.Random.Bool())
            .RuleFor(member => member.BirthDate, f => f.Date.Past(35))
            .RuleFor(member => member.CreatedDate, f => f.Date.Past(5))
            .RuleFor(member => member.DateJoined, f => f.Date.Past(5))
            .RuleFor(member => member.Email, f => f.Person.Email)
            .RuleFor(member => member.FirstName, f => f.Person.FirstName)
            .RuleFor(member => member.LastName, f => f.Person.LastName)
            .RuleFor(member => member.UserName, f => $"{f.Person.FirstName} {f.Person.LastName}")
            .RuleFor(member => member.PhoneNumber, f => f.Person.Phone)
            .RuleFor(member => member.Jmbg,
                f => f.Random.Double(1000000000000, 9999999999999).ToString("0000000000000"))
            .RuleFor(member => member.BloodType, f => f.PickRandom<BloodType>())
            .RuleFor(member => member.EmailConfirmed, f => f.Random.Bool())
            .RuleFor(member => member.PhoneNumberConfirmed, f => f.Random.Bool());
        return membersFaker.Generate(100);
    }
}