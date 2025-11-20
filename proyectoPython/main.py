import pika
import json

# Configuración de RabbitMQ
RABBITMQ_CONFIG = {
    "username": "admin",
    "password": "admin",
    "virtual_host": "/",
    "port": 5672,
    "hostname": "localhost",
    "queue_name": "ProductoMensaje"
}

def callback(ch, method, properties, body):
    print("\n📥 Mensaje recibido crudo:")
    print(body)

    try:
        data = json.loads(body.decode("utf-8"))
        print("\n📦 Mensaje procesado:")
        print(f"Id: {data['Id']}")
        print(f"Nombre: {data['Nombre']}")
        print(f"Descripcion: {data['Descripcion']}")
        print(f"CategoriaId: {data['CategoriaId']}")
        print(f"PrecioUnitario: {data['PrecioUnitario']}")

        valor = data['PrecioUnitario']

        #programar
        #metodo mysql


    except Exception as e:
        print("Error procesando el mensaje:", e)

def main():
    # Credenciales
    credentials = pika.PlainCredentials(
        RABBITMQ_CONFIG["username"],
        RABBITMQ_CONFIG["password"]
    )

    # Parámetros de conexión
    params = pika.ConnectionParameters(
        host=RABBITMQ_CONFIG["hostname"],
        port=RABBITMQ_CONFIG["port"],
        virtual_host=RABBITMQ_CONFIG["virtual_host"],
        credentials=credentials
    )

    print("Conectando a RabbitMQ...")
    connection = pika.BlockingConnection(params)
    channel = connection.channel()

    # Asegura que la cola exista
    channel.queue_declare(queue=RABBITMQ_CONFIG["queue_name"], durable=True)

    print(f"Esperando mensajes en la cola: {RABBITMQ_CONFIG['queue_name']}")
    
    # Consumir mensajes
    channel.basic_consume(
        queue=RABBITMQ_CONFIG["queue_name"],
        on_message_callback=callback,
        auto_ack=True
    )

    # Inicia escucha
    channel.start_consuming()


if __name__ == "__main__":
    main()
