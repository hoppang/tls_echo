package types

import (
	"encoding/json"
	"fmt"
	"log"
	"net"
)

type Message struct {
	Code    int
	StrArgs []string
	Client  net.Conn
}

type Communicator interface {
	Notify(msg Message)
}

func JsonToMessage(jsonText []byte) Message {
	var msg Message

	err := json.Unmarshal(jsonText, &msg)
	if err != nil {
		log.Fatalf("unmarshal err: %s\n", err)
	}

	return msg
}

func MessageToJsonBytes(msg Message) []byte {
	jsonBytes, err := json.Marshal(msg)
	if err != nil {
		log.Fatalf("marshal err: %v\n", err)
		return nil
	}

	return jsonBytes
}

func PrintMessage(msg Message) {
	fmt.Printf("Code:%d\n", msg.Code)
	for index, tag := range msg.StrArgs {
		fmt.Printf("Tag %d:%s\n", index, tag)
	}
}
