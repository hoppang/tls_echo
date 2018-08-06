package worker

import (
	"fmt"
	. "types"
)

type TestWorker struct {
	in chan Message
}

func NewTestWorker() *TestWorker {
	ret := &TestWorker{}
	ret.in = make(chan Message)

	return ret
}

func (self *TestWorker) PrintHello() {
	fmt.Printf("Hello Manager\n")
}

func (self *TestWorker) Notify(msg Message) {
	self.in <- msg
}

func (self *TestWorker) Run() {
	go func() {
		for {
			select {
			case inMsg := <-self.in:
				switch inMsg.Code {
				case REQ_ECHO:
					self.echoMessage(inMsg)
				default:
					fmt.Printf("unknown command: %v\n", inMsg.Code)
				}
			}
		}
	}()
}
