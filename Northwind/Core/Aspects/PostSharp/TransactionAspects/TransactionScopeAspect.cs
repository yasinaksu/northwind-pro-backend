using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Aspects.PostSharp.TransactionAspects
{
    [Serializable]
    public class TransactionScopeAspect : OnMethodBoundaryAspect
    {
        private readonly TransactionScopeOption _option;

        public TransactionScopeAspect(TransactionScopeOption option)
        {
            _option = option;
        }

        public TransactionScopeAspect()
        {

        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            args.MethodExecutionTag = new TransactionScope(_option);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Complete();
        }

        //hangisini kullanacağıma tam emin olamadım (transaction hata verdiğinde mi dispose ediliyor yoksa iş bittikten sonra mı dispose edilmeli ?)
        public override void OnExit(MethodExecutionArgs args)
        {
            //finally block
            ((TransactionScope)args.MethodExecutionTag).Dispose();
        }

        //hata anında bunu transaction ı sonlandırmak için bunu kullanmak daha mantıklı geldi
        //public override void OnException(MethodExecutionArgs args)
        //{
        //    catch block
        //    ((TransactionScope)args.MethodExecutionTag).Dispose();
        //}
    }
}
