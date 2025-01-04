using Castle.DynamicProxy;
using JheyPassword.Business.Responses;

namespace JheyPassword.Application.Services;

public class InterceptorService : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        try
        {
            // Executa o método original
            invocation.Proceed();

            // Verifica o tipo de retorno do método
            var returnType = invocation.Method.ReturnType;

            // Se o retorno não for void e não estiver encapsulado, transforma no formato esperado
            if (returnType != typeof(void) &&
                returnType.IsGenericType &&
                returnType.GetGenericTypeDefinition() != typeof(BaseResponse<>))
            {
                // Obtém o tipo genérico do retorno
                var resultType = returnType;

                // Cria um ServiceResult<T>.Success encapsulando o valor retornado
                var successMethod = typeof(BaseResponse<>)
                    .MakeGenericType(resultType)
                    .GetMethod(nameof(BaseResponse<object>.Success));

                invocation.ReturnValue = successMethod!.Invoke(null, new[] { invocation.ReturnValue });
            }
        }
        catch (Exception ex)
        {
            // Em caso de exceção, retorna um ServiceResult<T> com erro
            var returnType = invocation.Method.ReturnType;

            if (returnType.IsGenericType)
            {
                var resultType = returnType.GetGenericArguments()[0];
                var failureMethod = typeof(BaseResponse<>)
                    .MakeGenericType(resultType)
                    .GetMethod(nameof(BaseResponse<object>.Failure));

                invocation.ReturnValue = failureMethod!.Invoke(null, new object[] { ex.Message });
            }
            else
            {
                // Para métodos void, ignora
                invocation.ReturnValue = null;
            }
        }
    }
}