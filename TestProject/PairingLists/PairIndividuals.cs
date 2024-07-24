using Dumpify;

namespace TestProject.PairingLists;

public static class PairIndividuals
{
    public static Dictionary<string, List<string>> GetPairs(List<string> people)
    {
        people = people.OrderBy(x => x).ToList();

        List<string> pairings = people.GetPairings();

        pairings.Dump();

        var pairingsAndSubPairings = new Dictionary<string, List<string>>();

        pairings.ForEach(x =>
        {
            var pair = x.Split("-").ToList();
            var otherPeople = people.Where(y => !pair.Contains(y)).ToList();

            pairingsAndSubPairings.Add(x, otherPeople.GetPairings());
        });

        return default;
        // var result = pairings.Select(x =>
        //     (x, GetOtherPairings(pairings, x))).ToList().Dump();
        //
        // result.ForEach(x =>
        // {
        //     "First Pair:".Dump();
        //     $"{x.x.Item1} {x.x.Item2}".Dump();
        //
        //     "Secondary Pairs:".Dump();
        //     x.Item2.ForEach(y => { $"{y.Item1} {y.Item2}".Dump(); });
        // });
    }

    static List<string> GetPairings(this List<string> people)
    {
        return people
            .SelectMany((partner1, index) => people
                .Skip(index + 1)
                .Select(partner2 =>
                {
                    List<string> partners = [partner1, partner2];
                    return string.Join("-", partners.OrderBy(s => s));
                })).OrderBy(x => x).ToList();
    }
}