--drop PROCEDURE sp_masterafiliado
create PROCEDURE sp_masterafiliado
(@id int = NULL,
@nombre VARCHAR(50) = NULL,
@apellido VARCHAR(50) = NULL,
@sexo char(1) = NULL,
@fechanacimiento date = NULL,
@recaudo decimal(10, 2) = NULL,
@type NVARCHAR(20) = '')
AS
  BEGIN
      IF @type = 'Insert'
        BEGIN
           INSERT INTO [dbo].[AFILIADO]
           (
				[NOMBRE]
			   ,[APELLIDO]
			   ,[SEXO]
			   ,[FECHA_NACIMIENTO]
			   ,[RECAUDO]
		   )
			VALUES
           (
			   @nombre,
			   @apellido,
			   @sexo,
			   @fechanacimiento,
			   @recaudo
			   
		   )
        END

      IF @type = 'Select'
        BEGIN
            SELECT [ID]
			  ,[NOMBRE]
			  ,[APELLIDO]
			  ,[SEXO]
			  ,[FECHA_NACIMIENTO]
			  ,[RECAUDO]
			FROM [dbo].[AFILIADO]
        END

      IF @type = 'Update'
        BEGIN
            UPDATE [dbo].[AFILIADO]
			   SET [NOMBRE] = @nombre
				  ,[APELLIDO] = @apellido
				  ,[SEXO] = @sexo
				  ,[FECHA_NACIMIENTO] = @fechanacimiento
				  ,[RECAUDO] = @recaudo
			 WHERE [ID] = @id
        END
      ELSE IF @type = 'Delete'
        BEGIN
            DELETE FROM [dbo].[AFILIADO]
            WHERE  ID = @id
        END
  END
--   jonathan Rodriguez