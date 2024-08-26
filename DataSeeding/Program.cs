// See https://aka.ms/new-console-template for more information
// Wire Verifications portions

using DataSeeding;
using DataSeeding.Models;
using Dumpify;

var wireVerificationSeedData = new BoundedContextSeedData("Wire Verification Settings");
wireVerificationSeedData.AddUser(true, [UserAction.Viewer], UserRole.SuperAdmin);
wireVerificationSeedData.AddUser(true, [UserAction.Viewer], UserRole.TCA);
wireVerificationSeedData.AddUser(true, [UserAction.Viewer], UserRole.VCA);
wireVerificationSeedData.AddUser(false, [UserAction.Viewer, UserAction.Editor, UserAction.Canceller], UserRole.MSA);
wireVerificationSeedData.AddUser(false, [UserAction.Approver, UserAction.Decliner], UserRole.MSA);

wireVerificationSeedData.Dump();

wireVerificationSeedData.Users.Select(x => x.Name).ToList().Dump();
