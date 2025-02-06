namespace Core.Entities.Concrete
{
    public class UserOperationClaim : AuditBaseEntity, IEntity  
    {
        public int UserId { get; set; }

        public int? OperationClaimId { get; set; } = 4;

    }

}
