package worker

import (
	"log"
	. "types"
)

func (self *TestWorker) echoMessage(msg Message) {
	var retMsg Message
	retMsg.Code = RES_ECHO
	retMsg.StrArgs = msg.StrArgs

	conn := msg.Client
	jsonBytes := MessageToJsonBytes(retMsg)
	log.Printf("jsonBytes = %v, len = %v\n", string(jsonBytes), len(string(jsonBytes)))
	conn.Write(jsonBytes)
}
