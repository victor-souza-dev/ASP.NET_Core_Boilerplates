using PostSharp.Aspects;
using PostSharp.Serialization;
using System.Transactions;

namespace Infrastructure;

[PSerializable]
public class AsyncTransactionAttribute : MethodInterceptionAspect
{
    public override void OnInvoke(MethodInterceptionArgs args)
    {
        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            try
            {
                args.Proceed();
                scope.Complete();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro durante a transação: {ex.Message}");
                throw;
            }
        }
    }

}
