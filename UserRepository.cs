using pizzariaggn.models;

public async Task InsertUsuario (Usuario user, IFormFile arquivo){
 
 string caminhoArquivo = await  upload(arquivo, "img");

    using (var connection = _dbConnection.GetConnection()){

       using ( var command = connection.GetConnection()){


           
         command.commandText = "INSERT INTO usuario(nome,login,email,senha,foto) Values (@nome,@login,@email,@senha,@foto)";

        var nomeParam = command.CreateParameter();
        nomeParam.ParameterName = "@nome"
        nomeParam.Value =user.Nome;
        command.Parameters.add(nomeParam);

        var loginParam = command.CreateParameter();
        loginParam.ParameterName = "@login"
        loginParam.Value = user.login;
        command.Parameters.add(loginParam);

         var emailParam = command.CreateParameter();
        emailParam.ParameterName = "@login"
        emailParam.Value = user.Email;
        command.Parameters.add(emailParam);

         var senhaParam = command.CreateParameter();
        senhaParam.ParameterName = "@senha"
        senhaParam.Value =user.Senha;
        command.Parameters.add(senhaParam);
    
      user.Foto = caminhoArquivo;

        var fotoParam = command.CreateParameter();
        fotoParam.ParameterName ="@foto"
        fotoParam.Value =user.Foto;
        command.Parameters.add(fotoParam); 
    
   command.ExecuteNonQuery();

   }
  }
}
public async Task<string> Upload (IFormFile arquivo, string pasta){
     
      if(arquivo == null || arquivo.Length ==0){
        return "";
      }
      string caminhoPasta = Path.Combine(_webHostEnviroment.webRootPath,pasta);
      string caminhocompleto = Path.Combine(caminhoPasta,nomeArquivo);

      using(var stream = new FileStream(caminhocompleto,FileMode.Create)

      {
        await arquivo.CopyToAsync(stream);
      }
      return $"/{pasta}/{nomeArquivo}";

}