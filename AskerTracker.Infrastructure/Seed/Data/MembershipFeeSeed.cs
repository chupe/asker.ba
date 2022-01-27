using System;
using System.Collections.Generic;
using System.Linq;
using AskerTracker.Domain;
using Bogus;

namespace AskerTracker.Infrastructure.Seed.Data;

public static class MembershipFeeSeed
{
    public static List<MembershipFee> FakeFees(List<Member> fakeMembers)
    {
        var membershipFeesFaker = new Faker<MembershipFee>()
            .RuleFor(fee => fee.Id, new Guid())
            .RuleFor(fee => fee.Amount, x => x.Finance.Random.Number(1, 1000))
            .RuleFor(fee => fee.TransactionDate,
                x => x.Date.Past(5))
            .RuleFor(fee => fee.Member, x => x.PickRandom(fakeMembers));

        return membershipFeesFaker.Generate(1000);
    }
}