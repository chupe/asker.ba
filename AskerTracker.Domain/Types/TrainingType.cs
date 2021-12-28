namespace AskerTracker.Domain.Types
{
    public enum TrainingType
    {
        // [Display(ResourceType = typeof(UILocalization), Name = "Internal")]

        Internal,

        // [Display(ResourceType = typeof(UILocalization), Name = "Cooperation", Description = "training with other teams at home or away")]

        Cooperation,

        // [Display(ResourceType = typeof(UILocalization), Name = "Match")]

        Match,

        // [Display(ResourceType = typeof(UILocalization), Name = "Hiking")]

        Hiking,

        // [Display(ResourceType = typeof(UILocalization), Name = "Camping")]

        Camping,

        // [Display(ResourceType = typeof(UILocalization), Name = "Combat")]

        Combat,

        // [Display(ResourceType = typeof(UILocalization), Name = "Other")]

        Other
    }
}