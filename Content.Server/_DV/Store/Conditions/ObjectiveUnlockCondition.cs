using Content.Shared.Mind;
using Content.Shared.Store;
using Content.Server._DV.Objectives.Systems;

namespace Content.Server._DV.Store.Conditions;

/// <summary>
/// Requires that the buyer have an objective that unlocks this listing.
/// </summary>
public sealed partial class ObjectiveUnlockCondition : ListingCondition
{
    public override bool Condition(ListingConditionArgs args)
    {
        var ent = args.EntityManager;
        if (!ent.TryGetComponent<MindComponent>(args.Buyer, out var mind))
            return false;

        var unlocker = ent.System<StoreUnlockerSystem>();
        return unlocker.IsUnlocked(mind, args.Listing.ID);
    }
}
