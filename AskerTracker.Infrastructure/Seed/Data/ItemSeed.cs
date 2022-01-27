using System;
using System.Collections.Generic;
using AskerTracker.Domain;
using AskerTracker.Domain.Entities;
using Bogus;

namespace AskerTracker.Infrastructure.Seed.Data;

public static class ItemSeed
{
    public static List<Item> FakeItems(List<Member> fakeMembers)
    {

        var itemsFaker = new Faker<Item>()
            .RuleFor(item => item.Id, new Guid())
            .RuleFor(item => item.Amount, f => f.Random.Int(0, 10))
            .RuleFor(item => item.Comment, f => f.Lorem.Sentence())
            .RuleFor(item => item.Description, f => f.Lorem.Sentence())
            .RuleFor(item => item.Lender, f => f.PickRandom(fakeMembers))
            .RuleFor(item => item.Owner, f => f.PickRandom(fakeMembers))
            .RuleFor(item => item.Name, f => f.Commerce.Product())
            .RuleFor(item => item.Value, f => f.Finance.Random.Float(0, 1000F));

        return itemsFaker.Generate(100);
    }
}