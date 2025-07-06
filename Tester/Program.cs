using Tester;

Console.WriteLine(Validator.ToPostgreByteaLiteral(Validator.Hash("admin_password")));
Console.WriteLine(Validator.ToPostgreByteaLiteral(Validator.Hash("customer_password")));
