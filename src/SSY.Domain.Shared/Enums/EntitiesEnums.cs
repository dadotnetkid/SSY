namespace SSY.Enums;

public enum HolidayType
{
    Regular,
    Special,
    Local
}

public enum MediaFileType
{
    Unidentified = 0,
    Image,
    Video,
    Audio,
    File,
}

public enum Month
{
    Unidentified = 0,
    January = 1,
    February = 2,
    March = 3,
    April = 4,
    May = 5,
    June = 6,
    July = 7,
    August = 8,
    Septemper = 9,
    October = 10,
    November = 11,
    December = 12
}

public enum Status
{
    Unidentified = 0,
    Archived = 1,
    Eligible = 2,
    NotEligible = 3,
    InTalks = 4,
    ContractSent = 5,
    ContractSigned = 6,
    OnBoarded = 7,
    Support = 8
}

public enum AdditionRequestStatus
{
    Unidentified = 0,
    InProgress = 1,
    Completed = 2,
    CollectionCancelled = 3
}

public enum BulkPurchaseOrderRequestStatus
{
    Unidentified = 0,
    InProgress = 1,
    Completed = 2,
    Cancelled = 3
}
public enum CollectionStatus
{
    InProgress = 1001,
    OnHold = 1002,
    Confirmed = 1003
}

public enum AddressType
{
    Resindential = 0,
    Sampling
}

public enum BankType
{
    Paypal,
    Stripe,
    Payoneer,
    Wise
}

public enum RevenueShareType
{
    Personal,
    Agent
}