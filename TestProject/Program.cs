using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using Dumpify;
using TestProject.Models;
using TestProject.PairingLists;
using TestProject.Validation;
using TestProject.Validation.FluentVersion;


var pairs = PairIndividuals.GetPairs(["Frank", "Brock", "Riley", "Ben", "Rudy", "Tracy"]);
// pairs.Dump();
// pairs.Select(x => $"{x.Item1} - {x.Item2}").ToList().Dump();


// var ownAuth = new ParamsAuthorizer();
//
// var member = new Member(Guid.NewGuid(), MemberType.Member, true, true, true,
//     DateOnly.FromDateTime(DateTime.UtcNow));
//
// var test = new ValidParams(member, ["test"], new List<string>(),
//     DateOnly.FromDateTime(DateTime.UtcNow));
//
// ownAuth.Authorize(test);