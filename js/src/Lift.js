module.exports = function ({ id, floor, requests = [], doorsOpen }) {
    this.getId = () => id;
    this.getFloor = () => floor;
    this.getRequests = () => requests;
    this.areDoorsOpen = () => doorsOpen;

    this.hasRequestForFloor = (floor) => {
        return requests.includes(floor);
    }
}
