package server

import (
	"log"
	"net"
	. "types"
)

func (self *TlsServer) handleClient(conn net.Conn) {
	defer conn.Close()
	buf := make([]byte, 512)

	for {
		log.Print("server: conn: waiting")
		n, err := conn.Read(buf)
		if err != nil {
			if err != nil {
				log.Printf("server: conn: read: %s", err)
			}
			break
		}

		log.Printf("server: conn: echo %s (len %d)\n", string(buf[:n]), n)

		message := JsonToMessage(buf[:n])
		message.Client = conn
		self.worker.Notify(message)

		/*
			n, err = conn.Write(buf[:n])
			log.Printf("server: conn: wrote %d bytes", n)

			if err != nil {
				log.Printf("server: write: %s", err)
				break
			}
		*/
	}
	log.Println("server: conn: closed")
}
