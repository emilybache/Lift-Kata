package lift

import (
	"fmt"
	"strconv"
	"strings"
)

// Printer ..
type Printer interface{
	PrintLift(lift Lift, floor int) string
}

type simplePrinter struct {}

// NewSimplePrinter ..
func NewSimplePrinter() Printer {
	return 	&simplePrinter{}
}

// PrintLift ..
func (p simplePrinter) PrintLift(lift Lift, floor int) (liftStr string) {
	if inRequestedFloor(lift, floor){
		liftStr = fmt.Sprintf(" *%s ", lift.ID)
	} else {
		liftStr = fmt.Sprintf("  %s ", lift.ID)
	}
	return liftStr
}

type printer struct {}

// NewPrinter ..
func NewPrinter() Printer {
	return &printer{}
}

// PrintLift ..
func (p printer) PrintLift(lift Lift, floor int) (liftStr string) {
	if lift.DoorsOpen {
		if inRequestedFloor(lift, floor) {
			liftStr = fmt.Sprintf("]*%s[", lift.ID)
		} else {
			liftStr = fmt.Sprintf(" ]%s[", lift.ID)
		}
	
	} else {
		if inRequestedFloor(lift, floor){
			liftStr = fmt.Sprintf("[*%s]", lift.ID)
		} else {
			liftStr = fmt.Sprintf(" [%s]", lift.ID)
		}
	}
	return liftStr
}

// PrintLifts ...
func PrintLifts(liftSystem *System, liftPrinter Printer) string {
	result := ""
	floorNumberLength := calculateFloorNumberLength(liftSystem.floors)
	for _, floor := range reverseLiftFloors(liftSystem.floors) {
		calls := printCalls(liftSystem, floor)
		callPadding := whiteSpace(2 - len(calls))
		floorPadding := whiteSpace(floorNumberLength - len(strconv.Itoa(floor)))
		lifts := printLiftsForFloor(liftSystem, liftPrinter, floor)
		result += fmt.Sprintf("%s%d %s%s %s %s%d\n", 
		floorPadding, floor, strings.Join(calls, ""), callPadding, 
		strings.Join(lifts, " "), floorPadding, floor)
	}
	return result
}

func printLiftsForFloor(liftSystem *System, liftPrinter Printer, floor int) []string {
	lifts := []string{}
	for _, lift := range liftSystem.lifts {
		lifts = append(lifts, printLiftForFloor(liftPrinter, lift, floor))
	}
	return lifts
}

func printLiftForFloor(liftPrinter Printer, lift Lift, floor int) (liftStr string) {
	if lift.Floor == floor {
		liftStr = liftPrinter.PrintLift(lift, floor)
	} else {
		liftIDPadding := whiteSpace(len(lift.ID))
		if inRequestedFloor(lift, floor) {
			liftStr = fmt.Sprintf("  *%s", liftIDPadding)
		} else {
			liftStr = fmt.Sprintf("   %s", liftIDPadding)
		}
	}
	return liftStr
}

func inRequestedFloor(lift Lift, floor int) (found bool) {
	for _, request := range lift.Requests {
		if request == floor {
			found = true
		}	
	}
	return found
}

func printCalls(liftSystem *System, floor int) []string {
	calls := []string{}
	for _, call := range liftSystem.CallsFor(floor) {
		calls = append(calls, printCallDirection(call))
	}
	return calls
}

func printCallDirection(call Call) string {
	if call.Direction == Down {
		return "v"
	} else if call.Direction == Up {
		return "^"
	}
	return " "
}

func calculateFloorNumberLength(floors []int) int {
	if len(floors) < 1 {
		panic("Must have at least one floor")
	}
	lowestFloor := minInt(floors...)
	highestFloor := maxInt(floors...)
	longestFloorName := maxStringLength(strconv.Itoa(lowestFloor), strconv.Itoa(highestFloor))
	return len(longestFloorName)
}

func minInt(ints ...int) int {
	lowest := ints[0]
	for _, i := range ints {
		if i < lowest {
			lowest = i
		}
	}
	return lowest
}

func maxInt(ints ...int) int {
	highest := ints[0]
	for _, i := range ints {
		if i > highest {
			highest = i
		}
	}
	return highest
}

func maxStringLength(strings ...string) string {
	highest := strings[0]
	for _, s := range strings {
		if len(s) > len(highest) {
			highest = s
		}
	}
	return highest
}

func reverseLiftFloors(floors []int) []int {
	for i := len(floors)/2 - 1; i >= 0; i-- {
		opp := len(floors) - 1 - i
		floors[i], floors[opp] = floors[opp], floors[i]
	}
	return floors
}

func whiteSpace(length int) string {
	return strings.Repeat(" ", length)
}
