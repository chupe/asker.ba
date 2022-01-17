using System.Collections.Generic;
using AskerTracker.Domain;
using AskerTracker.Domain.Types;
using AskerTracker.Infrastructure.Extensions;
using Bogus;

namespace AskerTracker.Infrastructure.Seed.Data;

public static class MemberSeed
{
    public static List<Member> FakeMembers()
    {
        var membersFaker = new Faker<Member>()
            .RuleFor(member => member.Id, f => BogusConfiguration.StartId = BogusConfiguration.StartId.Increment())
            .RuleFor(member => member.Active, f => f.Random.Bool())
            .RuleFor(member => member.BirthDate,
                f => f.Date.Between(BogusConfiguration.MinDate, BogusConfiguration.MaxDate))
            .RuleFor(member => member.CreatedDate,
                f => f.Date.Between(BogusConfiguration.MinDate, BogusConfiguration.MaxDate))
            .RuleFor(member => member.DateJoined,
                f => f.Date.Between(BogusConfiguration.MinDate, BogusConfiguration.MaxDate))
            .RuleFor(member => member.Email, f => f.Person.Email)
            .RuleFor(member => member.UserName, f => f.Person.UserName)
            .RuleFor(member => member.FirstName, f => f.Person.FirstName)
            .RuleFor(member => member.LastName, f => f.Person.LastName)
            .RuleFor(member => member.PhoneNumber, f => f.Person.Phone)
            .RuleFor(member => member.JMBG,
                f => f.Random.Double(1000000000000, 9999999999999).ToString("0000000000000"))
            .RuleFor(member => member.BloodType, f => f.PickRandom<BloodType>())
            .RuleFor(member => member.EmailConfirmed, f => f.Random.Bool())
            .RuleFor(member => member.PhoneNumberConfirmed, f => f.Random.Bool());

        return membersFaker.Generate(100);
    }
}