CREATE PROC FI_SP_PesqBeneficiario
    @iniciarEm int,
	@quantidade int,
	@campoOrdenacao varchar(200),
	@crescente bit,
	@idCliente bigint
AS
BEGIN
	DECLARE @SCRIPT NVARCHAR(MAX)
	DECLARE @CAMPOS NVARCHAR(MAX)
	DECLARE @ORDER VARCHAR(50)
	
   	IF(@campoOrdenacao = 'NOME')
		SET @ORDER =  ' NOME '
	ELSE
		SET @ORDER = ' CPF '

	IF(@crescente = 0)
		SET @ORDER = @ORDER + ' DESC'
	ELSE
		SET @ORDER = @ORDER + ' ASC'
			
	SELECT ID, NOME, CPF, IDCLIENTE FROM
		(SELECT ROW_NUMBER() OVER (ORDER BY @ORDER) AS Row, ID, NOME, CPF, IDCLIENTE FROM BENEFICIARIOS WITH(NOLOCK) WHERE IDCLIENTE = @idCliente)
		AS BeneficiariosWithRowNumbers
	WHERE Row > @iniciarEm AND Row <= (@iniciarEm+@quantidade)			
	
	SELECT COUNT(1) FROM BENEFICIARIOS WITH(NOLOCK) WHERE IDCLIENTE = @idCliente
	
END