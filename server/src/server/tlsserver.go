package server

import (
	"crypto/rand"
	"crypto/tls"
	"crypto/x509"
	"fmt"
	"log"
	"net"
	. "types"
)

type TlsServer struct {
	worker   Communicator
	listener net.Listener
	in       chan Message
}

func NewTlsServer() *TlsServer {
	ret := &TlsServer{}
	ret.in = make(chan Message)

	return ret
}

func (self *TlsServer) PrintHello() {
	fmt.Printf("This is TlsServer\n")
}

func (self *TlsServer) Run() {
	fmt.Printf("%v Listen...", self)
	for {
		conn, err := self.listener.Accept()
		if err != nil {
			fmt.Printf("Accept error: %s\n", err)
			break
		}
		defer conn.Close()

		fmt.Printf("Accepted from %s\n", conn.RemoteAddr())
		tlscon, ok := conn.(*tls.Conn)
		if ok {
			fmt.Printf("ok = true\n")
			state := tlscon.ConnectionState()
			for _, v := range state.PeerCertificates {
				log.Print(x509.MarshalPKIXPublicKey(v.PublicKey))
			}
		}

		go self.handleClient(conn)
	}
}

func (self *TlsServer) Init() {
	cert, err := tls.LoadX509KeyPair(CERT_FILE, KEY_FILE)
	if err != nil {
		fmt.Printf("loadkey err: %s\n", err)
	}

	config := tls.Config{Certificates: []tls.Certificate{cert}}
	config.Rand = rand.Reader
	service := "0.0.0.0:9081"

	self.listener, err = tls.Listen("tcp", service, &config)
	if err != nil {
		fmt.Printf("listen err: %s\n", err)
	}
}

func (self *TlsServer) SetWorker(NewWorker Communicator) {
	self.worker = NewWorker
}

func (self *TlsServer) Notify(msg Message) {
	fmt.Printf("TlsServer Notify: %v\n", msg)
	self.in <- msg
}
