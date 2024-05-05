#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <pthread.h>

#define Max 30
#define Max2 100
#define buffer 512

// Variables para la implementacion de una lista de sockets
int socket_num = 0;
int sockets[100];

pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

typedef struct{
	int con;
	char Nombre [Max];
	int jugando;
	int Socket
} Usuario;
typedef struct {
	Usuario usuarios[Max2];
	int num;
} ListaUsuarios;
// Estructura para almacenar partida:
// -> un identifiacor
// -> una lista de los jugadores
// -> una lista de bools de los jugadores que han confirmado la participacion
// -> un integer que tomara los valores de 1 o 3 en funcion de la cantidad de 
//    jugadores que queramos que haya en la partida (ya que se puede jugar en 
//	  individual o por parejas, es decir, 1vs1 o 2vs2 de esta manera tenemos un
//	   "contador" maximo de la cantidad de gente que hay en la lista) 
// -> un booleano sobre si la partida ha iniciado o no.
typedef struct{
	int id;
	Usuario jugadores[4];
	int confirmaciones[4];
	int mode;
	int init;
} Partida;
// Estructura para almacenar las partidas activas
typedef struct {
	Partida partidas[Max];
	int num;
} ListaPartidas;

typedef struct{
	int id;
	char palo[Max];
	int numero;
} Carta;

typedef struct {
	Carta cartas[Max];
	int num;
} ListaCartas;


ListaUsuarios Usuarios;
ListaUsuarios Conectados;
int  conectados_num;
int Usuarios_num;
ListaPartidas Partidas;
ListaCartas Cartas;

int GenerarListaUsuarios(ListaUsuarios *lista, MYSQL *conn){
	// Esta funcion modifica la lista y devuelve el numero de usuarios en la base de datos
	// Si no se puede conectar a la base de datos devuelve -1
	int err;
	MYSQL_RES * resultado;
	MYSQL_ROW * row;
	char consulta[buffer];
	strcpy(consulta, "SELECT Nombre FROM Usuarios");
	err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		return -1;
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row(resultado);
	int num = 0;
	while (row != NULL)
	{
		strcpy(lista->usuarios[num].Nombre, row[0]);
		lista->usuarios[num].con = 0;
		lista->usuarios[num].jugando = 0;
		lista->usuarios[num].Socket = NULL;
		printf("%s\n",lista->usuarios[num].Nombre);
		num++;
		row = mysql_fetch_row(resultado);
	}
	lista->num = num;
	return num;
}
int ActualizarListaUsuarios(ListaUsuarios *lista, char nombre[Max]){
	// Funcion para concatenar un usuario a la lista, se usara para Register de forma mas ordenada
	// num declara la ultima posicion de la lista
	int num = lista->num;
	// Detecta si la lista esta llena
	if(num < Max2){
		strcpy(lista->usuarios[num].Nombre, nombre);
		lista->usuarios[num].con = 0;
		lista->usuarios[num].jugando = 0;
		lista->usuarios[num].Socket = NULL;
		num++;
		return 0;
	}
	else
		return 1;
}	

int DarConectados(ListaUsuarios *lista, ListaUsuarios *conectados){
	// Rellena una lista de usuarios conectados con la info de la lista general
	// Primero borramos el contenido de la lista de conectados
	for(int i=0; i <= conectados->num; i++)
	{	strcpy(conectados->usuarios[i].Nombre,"\0");
		conectados->usuarios[i].con = NULL;
		conectados->usuarios[i].jugando = NULL;
		lista->usuarios[i].Socket = NULL;
	}
	// Rellenamos la lista de conectados a prtir de la general
	conectados->num = 0;
	int j=0;
	for(int i=0; i <= lista->num; i++)
	{
		if(lista->usuarios[i].con == 1)
		{	// no se si funciona jajajaj
			strcpy(conectados->usuarios[j].Nombre,lista->usuarios[i].Nombre);
			conectados->usuarios[j].con = lista->usuarios[i].con;
			conectados->usuarios[j].jugando = lista->usuarios[i].jugando;
			conectados->usuarios[j].Socket = lista->usuarios[i].Socket;
			conectados->num++;
			j++;
		}
	}
	// El numero de personas conectadas
	return j;
}

int Register(char *p, char consulta[buffer], MYSQL *conn, ListaUsuarios *lista){
	// Hacemos la querry para detectar si el usuario ya existe
	int err;
	MYSQL_RES *resultado;
	
	p = strtok( NULL, "/");
	char nombre[30];
	strcpy (nombre, p);
	strcpy(consulta, "SELECT * FROM Usuarios WHERE Nombre = '");
	strcat(consulta, nombre);
	strcat(consulta,"'");
	err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		return 1;
	}
	int fila;
	resultado = mysql_store_result (conn);
	fila = mysql_num_rows(resultado);
	//printf("Hay %i usuarios con ese nombre.\n", fila);
	
	// El usuario ya existe
	if(fila != 0)
		return 2;
	memset(consulta, 0, buffer);
	// El usuario aun no existe
	p = strtok( NULL, "/");
	char mail[40];
	strcpy (mail,p);
	printf("mail: %s \n",mail);
	p = strtok( NULL, "/");
	char password[20];
	strcpy (password,p);
	printf("pass: %s \n",password);
	
	
	strcpy(consulta, "INSERT INTO Usuarios ");
	strcat(consulta, "(Nombre, Correo, Password) VALUES ('");
	strcat (consulta, nombre); 
	strcat (consulta, "','");
	strcat (consulta, mail); 
	strcat (consulta, "','");
	strcat (consulta, password); 
	strcat (consulta, "')");
	printf("consulta = %s\n", consulta);
	// Ahora ya podemos realizar la insercion 
	err = mysql_query(conn, consulta);
	if (err!=0) {
		printf ("Error al introducir datos la base %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	// Ahora hay que actualizar la lista de usuarios
	err = ActualizarListaUsuarios(lista, nombre);
	if (err == 1){
		printf("No se ha podidio agregar el usuario a la lista\n");
		return 1;
	}
	else
		return 0;			
}

int LogIN(char *p, MYSQL *conn, char info[buffer], ListaUsuarios *lista, int Socket){
	// SELECT PASSWORD FROM USERS WHERE NOMBRE = <nombre>;
	char consulta[buffer];
	int err;
	MYSQL_RES *resultado;	
	MYSQL_ROW *row;
	
	p = strtok( NULL, "/");
	char nombre[30];
	strcpy (nombre, p);
	p = strtok( NULL, "/");
	char password[30];
	strcpy (password, p);
	strcpy(consulta, "SELECT Password FROM Usuarios WHERE Nombre = '");
	strcat(consulta, nombre);
	strcat(consulta, "'");
	err = mysql_query(conn, consulta);
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	char realpass[30];	
	if (row == NULL)
	// No se ha encontrado el usuario
		return 1;
	else
	{	
		// Se convierte en un str comparable la password encontrada
		sprintf (realpass, "%s", row[0] );
	}
	// La password coincide con la que se ha dado
	if(strcmp(password, realpass) == 0)
	{
		mysql_free_result(resultado);
		strcpy(consulta, "SELECT Nombre, Correo FROM Usuarios WHERE Nombre = '");
		strcat(consulta, nombre);
		strcat(consulta, "'");
		err = mysql_query(conn, consulta);
		
		// Devuelve diversa info del usuario al cliente durante el inicio de sesion
		resultado = mysql_store_result(conn);
		row = mysql_fetch_row(resultado);
		strcpy(info,nombre);
		strcat(info,"/");
		strcat(info,row[1]);
		// Busca el usuario en la lista de usuarios y lo define como conectado
		int i = 0;
		while (strcmp(lista->usuarios[i].Nombre, nombre) != 0)
			i++;
		lista->usuarios[i].con = 1; 
		lista->usuarios[i].Socket = Socket;
		// Debugg
	printf("Estado actualizado:\n");
	printf("-> Nombre: %s\n",lista->usuarios[i].Nombre);
	printf("-> Conectado? %i\n",lista->usuarios[i].con);
	printf("-> Socket: %i\n",lista->usuarios[i].Socket);
		return 0;
	}
	// Password incorrecta
	else	
		return 2;
}

int LogOUT(char *p, ListaUsuarios *lista){
	// Cambiaremos la lista de conectados para decir que se ha cerrado sesion
	p = strtok( NULL, "/");
	char nombre[30];
	strcpy (nombre, p);
	int i = 0;
	while (strcmp(lista->usuarios[i].Nombre, nombre) != 0)
		i++;
	// Debugg
	printf("%s\n",lista->usuarios[i].Nombre);
	lista->usuarios[i].con = 0; 
	printf("%i\n",lista->usuarios[i].con);
	return 0;
}
int CrearPartida(char *p, ListaPartidas *partidas, ListaUsuarios *usuarios){
	// Crearemos una nueva partida con los jugadores antes de invitarlos, 
	// iniciaremos con confirmaciones a 0.
	// Devuelve la id de la partida o -1 si no se puede agregar mas partidas
	int num = partidas->num;
	if (num == Max2)
		return -1;

	p = strtok(NULL, "/");
	int mode = atoi(p);
	partidas->partidas[num].mode = mode;
	int j = 0;

	p = strtok(NULL, "/");
	char jugador[Max];
	while (p != NULL)
	{
		strcpy(jugador, p);
		for (int i = 0; i < usuarios->num; i++){
			if (strcmp(usuarios->usuarios[i].Nombre, jugador) == 0)
			{
				strcpy(partidas->partidas[num].jugadores[j].Nombre, usuarios->usuarios[i].Nombre);
				partidas->partidas[num].jugadores[j].Socket = usuarios->usuarios[i].Socket;
				partidas->partidas[num].jugadores[j].con = usuarios->usuarios[i].con;
				partidas->partidas[num].jugadores[j].jugando = usuarios->usuarios[i].jugando;
			}
		}
		p = strtok(NULL, "/");
		j++;
	}
	partidas->num++;
	return num;
}

int AceptarPartida(int id_partida, int aceptado, char persona[Max], ListaPartidas *Partidas){
	// El mensaje de respuesta a una  invitacion devolvera una referencia 
	// a la partida para identifiacarla, el nombre de la persona que a 
	// responde i un booleano indicando si acepta (1) o no (0)


	int num_jugador = 0;
	int i = 0;
	int encontrado  = 0;
	while((i <= strlen(Partidas->partidas[id_partida].jugadores)) && (encontrado == 0)){
		if(strcmp(Partidas->partidas[id_partida].jugadores[i].Nombre, persona) == 0)
			num_jugador = i;
			encontrado = 1;
		i++;
	}


	if (aceptado == 1){
		Partidas->partidas[id_partida].confirmaciones[num_jugador] = 1;
		return 1;
	} 
	else if(aceptado == 0){
		Partidas->partidas[id_partida].confirmaciones[num_jugador] = 0;
		return 0;
	}
}

int ComprovarInicioPartida(int id_partida, ListaPartidas *Partidas){
	// Esta funcion tiene que buscar una paritda segun su id i comprobar que todos los jugadores
	// segun el mode (1 o 3) hayan aceptado la partida (1) o no (-1) en la lista de confirmaciones
	// (sin responder 0). Devuelve 1 si se empieza la partida, 0 si todavia no y -1 si se ha cancelado
	if (Partidas->partidas[id_partida].init == -1){
		// Ya se habia cancelado antes
		return -1;
	}
	else
	{
		int mode = Partidas->partidas[id_partida].mode;
		int initCount = 0;
		for (int i = 0; i <= mode; i++){
			if(Partidas->partidas[id_partida].confirmaciones[i] == 1)
				initCount++;
			else if(Partidas->partidas[id_partida].confirmaciones[i] == -1)
			{
				Partidas->partidas[i].init = -1;
				return -1;
			}
		}
		if (initCount == mode)
		{
			Partidas->partidas[id_partida].init = 1;
			return 1;
		}
		else	
			return 0;
	}
}

int BuscarPartidaPorID(int id_partida,ListaPartidas *Partidas){ 
	//funcion que retorna la posicion de la partida -1 si hay error
	int enc = 0;
	for (int i=0; i <= Partidas->num;i++)
	{
		if (Partidas->partidas[i].id == id_partida)

			return  i;

	}
	if (enc == 0)
	return -1;
}

void GenerarListaCartas (MYSQL *conn, ListaCartas *listaCartas){
	//Generar lista de todas cartas al iniciar servidor en el main

	int err;
		MYSQL_RES * resultado;
		MYSQL_ROW * row;
		char consulta[buffer];
		strcpy(consulta, "SELECT ID,Nombre,Fuerza,Posicion FROM Cartas");

		err=mysql_query (conn, consulta);
		if (err!=0) {
			printf ("Error al consultar datos de la base %u %s\n",
					mysql_errno(conn), mysql_error(conn));
			return -1;
		}

		resultado = mysql_store_result (conn);
		row = mysql_fetch_row(resultado);
		int num = 0;
		while (row != NULL)
		{
			listaCartas->cartas[num].id =  row[0];
			strcpy(listaCartas->cartas[num].palo, row[1]);
			listaCartas->cartas[num].numero = row[2];
			// printf("%s\n",lilistaCartassta->usuarios[num].Nombre);
			num++;
			row = mysql_fetch_row(resultado);
		}
}

void DarCarta (ListaCartas *Cartas, int ID, Carta *carta){ 
	//meter en carta su informacion en funcion de ID

	for (int i = 0 ; Cartas->num; i++)
	{ 
		if (ID == Cartas->cartas[i].id)
		{
			carta->id = i;
			strcpy(carta->palo,Cartas->cartas[i].palo);
			carta->numero = Cartas->cartas[i].numero;
		}

	}
}

void DarMano(char *respuesta, ListaCartas *Cartas, int numMano){ 
//Da una mano a cada jugador de la partida que pide a partir de la lista de todas cartas
// Opcion 1): mas ancho de banda
//formato de respuesta: 8/numeroCartas/ID1/Carta_Palo1/Cart_NBumero1
//Opcion 2): base de datos en cliente tambien
	int i=0;
	int num_ID;   
	Carta carta;
	strcpy(respuesta, "8/");
	sprintf(respuesta, "%s/%d" , respuesta, numMano);
    //printf (" Rand de 1 a 52 \n");  
    while (i<=numMano)  
    {  
        num_ID = rand() % Cartas->num + 1; // obtener num aleatorio entre 1 y 52
		if (num_ID = 1)
		{
			DarCarta(&Cartas, num_ID, &carta);
			//1) 
			//sprintf(respuesta, "%s/%d",respuesta,num_ID,carta.palo,carta.numero);
			//2)
			sprintf(respuesta, "%s/%d/",respuesta,num_ID); //opcion en la que el cliente tiene toda la info
			i++;
		}

		else
		{
			DarCarta(&Cartas, num_ID, &carta);
			//1) 
			//sprintf(respuesta, "%s/%d",respuesta,num_ID,carta.palo,carta.numero);
			//2)
			sprintf(respuesta, "%s/%d/",respuesta,num_ID);
			i++;
		}

		sprintf(respuesta, "%s/", respuesta); //cerrar mensaje
		printf("Mano: %s\n",respuesta);

	}

}

int CancelarPartida(int id_partida, ListaPartidas *Partidas)
{

}


void *AtenderCliente(void *socket){
	// Iniciamos el socket dentro del thread
	int sock_conn;
	int *s;
	s= (int*) socket;
	sock_conn= *s;
	
	// Empezamos bucle para el analisis de peticiones
	int  terminar = 0;
	while (terminar == 0)
	{	
		// Re/iniciamos los buffers
		char buff[buffer];
		char notificacion[buffer];
		char respuesta[buffer];
		//--------------------------SQL Main Connection-------------------------
		MYSQL *conn;
		int err;
		char consulta [buffer];
		//Creamos una conexion al servidor MYSQL 
		conn = mysql_init(NULL);
		if (conn==NULL) {
			printf ("Error al crear la conexion: %u %s\n", 
					mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		//inicializar la conexion
		conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "BBDDG1",0, NULL, 0);
		if (conn==NULL) {
			printf ("Error al inicializar la conexion: %u %s\n", 
					mysql_errno(conn), mysql_error(conn));
			exit (1);
		}				
		//--------------------------SQL Main Connection-------------------------	
		// Ahora recibimos la request del cliente, que dejamos en buff
		int ret =read(sock_conn,buff, sizeof(buff));
		printf ("Recibido:\n");

		// Tenemos que agregar la marca de fin de string 
		// para que no escriba lo que hay despues en el buffer
		buff[ret] = '\0';
		printf("%s.\n", buff);

		// Detectamos el servicio que se pide
		char *p = strtok(buff, "/");
		int codigo = atoi (p);
		//printf("El codigo es: %i\n",codigo);
		// A partir de aqui se seleccionara el servicio y se ejecutara
		switch (codigo){
			// Registro de usuario
			// Recibe: 1/<Nombre>/<Correo>/<Password>
			case 1:	{
				// Se niega el acceso a otros theads para evitar registrar dos 
				// usuarios con la misma ID
				pthread_mutex_lock(&mutex);
				int res = Register(p, consulta, conn, &Usuarios);
				// printf("Respuesta es: %i\n", res);
				pthread_mutex_unlock(&mutex);
				if (res == 0)
				{	
					sprintf(respuesta,"1/Se ha registrado el usuario");
				}
				else if (res == 1)
				{
						sprintf(respuesta,"1/Error durante el registro");
				}
				else if (res == 2)
				{	
					// Una de las condiciones es que tengan misma ID, de todas formas
					// ya no tendria que ocurrir nunca
					sprintf(respuesta,"1/Este usuario ya estaba registrado");
				}
				}
			// Inicio de sesion
			// Recibe: 2/<Nombre>/<Password>
			case 2:{	
				char info[buffer];
				pthread_mutex_lock(&mutex);
				int res = LogIN(p, conn, info, &Usuarios,sock_conn);
				pthread_mutex_unlock(&mutex);
				// printf("res es: %i", res);
				if (res == 0)
				{
					sprintf(respuesta,"2/Se ha iniciado sesion");
					// Poner funcion para buscar toda la info del jugador
					strcat(respuesta, "/");
					// De momento solo devuelve el correo con el nombre, pero
					// en el futuro se usara para enviar mas info al iniciar.
					// Por ejemplo: lista de amigos
					strcat(respuesta, info);
				}
				else if (res == 1)
				{
						sprintf(respuesta,"2/No se ha encontrado el usuario");
				}
				else if (res == 2)
				{
					sprintf(respuesta,"2/La password es incorrecta");
				}	
								break;
			}
			//Crear Partida
			case 3:{
				pthread_mutex_lock(&mutex);
				int res = CrearPartida(p, &Partidas, &Conectados);
				pthread_mutex_unlock(&mutex);
				if (res  == -1){
					// se va a tomar por culo.
					strcpy(respuesta, "No se ha podido crear la partida");
					write(sock_conn,respuesta, strlen(respuesta));
				}
				else {
					// invitamos
					char invitacion[buffer];
					// 4/<id de partida>/<Persona que ha invitado>
					sprintf(invitacion,"4/%i/%s", res, Partidas.partidas[res].jugadores[0].Nombre);
					printf("Invitacion: %s \n", invitacion);
					for(int i = 1; i <= Partidas.partidas[res].mode; i++){
						write(Partidas.partidas[res].jugadores[i].Socket, invitacion, strlen(invitacion));
					}
				}

				break;
			}
			// LogOut
			// Recibe: 4/<Nombre>
			case 4:{
				pthread_mutex_lock(&mutex);
				int res = LogOUT(p, &Usuarios);
				if(res == 0)sprintf(respuesta,"4/Se ha cerrado la sesion\n");
				pthread_mutex_unlock(&mutex);
				break;
			}
			// Aceptar partida
			// Recibe: 5/<id de partida>/<acepta o no>/<nombre de la persona que acepta>
			case 5:{
				pthread_mutex_lock(&mutex);
				p = strtok(NULL, "/");
				int id_partida = atoi(p);
				p = strtok(NULL, "/");
				int aceptado = atoi(p);
				p = strtok(NULL, "/");
				char persona[Max];
				strcpy(persona, p);

				int res = AceptarPartida(id_partida, aceptado, persona, &Partidas);
				pthread_mutex_unlock(&mutex);
				if (res == 0)
				{
					sprintf(respuesta, "5/0/%s", persona);
					printf("Respuesta: %s\n", respuesta);
					write(Partidas.partidas[id_partida].jugadores[0].Socket,
							respuesta, strlen(respuesta));
					// Funcion para cancelar la partida y notificar a los jugadores.
				}
				else if(res == 1)
				{
					sprintf(respuesta, "5/1/%s", persona);
					printf("Respuesta: %s\n", respuesta);
					write(Partidas.partidas[id_partida].jugadores[0].Socket,
							respuesta, strlen(respuesta));
					// Funcion para comprovar si la partida esta lista + enviar notificacion para
					// empezar a jugar a todos los jugadores.
					pthread_mutex_lock(&mutex);
					int res2 = ComprovarInicioPartida(id_partida, &Partidas);
					pthread_mutex_unlock(&mutex);
					if (res2 == 1){
						// Iniciar partida
						sprintf(respuesta, "6/%i/Se va a iniciar la partida %i.", id_partida, id_partida);
						printf("Respuesta: %s\n", respuesta);
						for (int i=0;i<= Partidas.partidas[id_partida].mode; i++)
						write(Partidas.partidas[id_partida].jugadores[i].Socket,
							respuesta, strlen(respuesta));
					}
					// Si se cancela solo lo sabra el que ha creado la partida.
				}
				break;
			}
			case 6:{
				p = strtok(NULL, "/");
				int id_partida = atoi(p);
				p = strtok(NULL, "/");
				char persona[Max];
				strcpy(persona, p);
				p = strtok(NULL, "/");
				char mensaje[Max2];
				strcpy(mensaje, p);

				sprintf(respuesta, "7/%i/%s/%s", id_partida,persona, mensaje);
				printf("Respuesta: %s\n", respuesta);
				for (int i=0;i<= Partidas.partidas[id_partida].mode; i++)
				write(Partidas.partidas[id_partida].jugadores[i].Socket,
					respuesta, strlen(respuesta));
				break;
			}
				case 7:{ //Inicio de partida, desde lobby


				p = strtok(NULL, "/");
				int id_partida = atoi(p);
				int posPartida = BuscarPartidaPorID(id_partida, &Partidas);
				//p = strtok(NULL, "/");
				//int numCartas = atoi(p);
				int numCartas = 10; //arbitrario, se cambiara cuando haya lobby
				if (posPartida != -1)
				{
					for (int i=0;i<= 4; i++)
					{
						if (Partidas.partidas[posPartida].jugadores[i].jugando == 1) //damos mano a jugador que juega
						{
							DarMano(respuesta, &Cartas, numCartas);
							write(Partidas.partidas[posPartida].jugadores[i].Socket,
							respuesta, strlen(respuesta));
						}
					}
				}
				else if (posPartida == -1)
					printf("Partida no encontrada.\n");
				break;
			}

			case 8:{ //Accion en turno->poner carta en tablero debe ser visible para todos

			//el turno puede acabar de distintas formas, cuando todos jugadores han pasado 
			// se recibe el estado a final de turno del tablero->invocamos una funcion de recuento desarrollada mas arriba

				printf("Se ha desconectado.\n");
				terminar = 1;
				break;
			}

			case 9:{ //Fin turno y fin partida

			//el turno acba cuando todos jugadores han pasado 
			// se recibe el estado a final de turno del tablero->invocamos una funcion de recuento desarrollada mas arriba

				printf("Se ha desconectado.\n");
				terminar = 1;
				break;
			}

			//case 9:{ //Fin partida
			//	printf("Se ha desconectado.\n");
			//	terminar = 1;
			//	break;
			//}

			// Mensaje de desconexion
			case 0:{
				printf("Se ha desconectado.\n");
				terminar = 1;
				break;
			}
			}
		}
		// Si el mensaje no es de desconexion, cerramos la conexion a mysql y enviamos 
		// la respuesta al cliente

		// Re/iniciamos los buffers
		char buff[buffer];
		char notificacion[buffer];
		char respuesta[buffer];
		//--------------------------SQL Main Connection-------------------------
		MYSQL *conn;
		int err;
		char consulta [buffer];
		//Creamos una conexion al servidor MYSQL 
		conn = mysql_init(NULL);
		char *p = strtok(buff, "/");
		int codigo = atoi (p);
		

		if ((codigo != 0) && (codigo != 3) && (codigo != 4) && (codigo != 5)){
			mysql_close(conn);
			printf("Respuesta: %s\n", respuesta);
			write(sock_conn, respuesta, strlen(respuesta));
		}
		// Generacion de la notificacion de conectados
		if ((codigo == 1) || (codigo == 2) || (codigo == 4)){
			pthread_mutex_lock(&mutex);
			conectados_num = DarConectados(&Usuarios, &Conectados);
			if(conectados_num != 0){
				sprintf(notificacion,"3/%d",conectados_num);
				for(int i = 0; i < conectados_num; i++ ){
					sprintf(notificacion,"%s/%s",notificacion,Conectados.usuarios[i].Nombre);
					// Debugg para consola
					printf("Conectado: %s\n", Conectados.usuarios[i].Nombre);
				}	
			}
			else if(conectados_num == 0)
				strcpy(notificacion,"3/0/");
			pthread_mutex_unlock(&mutex);
			printf("Notificacion: %s\n", notificacion);
			for (int j = 0; j < conectados_num; j++)
				write(sockets[j], notificacion, strlen(notificacion));
		
	}
	close(sock_conn);
}
int main(int argc, char *argv[]){
	//------------------------------Iniciamos Servidor-----------------------------------
	int sock_conn, sock_listen;
	struct sockaddr_in serv_adr;
	// INICIALIZACIONES
	// Abrimos el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Hacemos el bind al puerto, inicializa a zero serv_addr
	memset(&serv_adr, 0, sizeof(serv_adr));
	serv_adr.sin_family = AF_INET;
	// asocia el socket a cualquiera de las IP de la maquina. 
	// htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// escucharemos en el port 50060
	serv_adr.sin_port = htons(50060);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	// La cola de peticiones pendientes no podra ser superior a 4
	if (listen(sock_listen, 4) < 0)
		printf("Error en el Listen");
	
	MYSQL *conn;
	int err;
	char consulta [buffer];
	//Creamos una conexion al servidor MYSQL 
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//inicializar la conexion
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "TG3_BDDJuego",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}

	// Rellenamos la lista de usuarios en el servidor con la informacion del la BBDD
	Usuarios_num = GenerarListaUsuarios(&Usuarios, conn);
	GenerarListaCartas(conn, &Cartas);
	mysql_close(conn);
	// Cerramos conexion mysql para ahorrar recursos
	
	// Generamos las variables necesarias para la utilizacion de threads para cada cliente
	pthread_t thread;
	// Atenderemos a infinitas peticiones
	for(;;){
		printf ("Escuchando\n");
		//sock_conn es el socket que usaremos para este cliente
		//Aqui aceptamos la peticion de del cliente
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion \n");
		// Generamos los threads para cada conexion		
		sockets[socket_num] = sock_conn;
		pthread_create (&thread, NULL, AtenderCliente, &sockets[socket_num]);
		socket_num++;
	}
}
