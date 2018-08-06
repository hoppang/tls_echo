// TagManager project main.go
package main

import (
	"server"
	"worker"
)

func main() {
	server := server.NewTlsServer()
	server.Init()

	workerObj := worker.NewTestWorker()
	workerObj.Run()

	server.SetWorker(workerObj)
	server.Run()
}
