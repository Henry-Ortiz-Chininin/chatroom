
let form = document.forms[0];
let NewCurrentRoomId = $("#NewCurrentRoomId");
let RemoveRoomId = $("#RemoveRoomId");
let RemoveMateId = $("#RemoveMateId");
let CurrentAction = $("#CurrentAction");
let ChatPanel = $("#ChatPanel");

let heightView = Math.round(window.innerHeight * 0.8);

ChatPanel.height(heightView);

window.addEventListener("resize", function () {
    heightView = Math.round(window.innerHeight * 0.8);
    ChatPanel.height(heightView);
});

function SelectRoom(RoomId) {
    NewCurrentRoomId.val(RoomId);
    CurrentAction.val("Open Room");
    form.submit();
}

function AddMate() {
    CurrentAction.val("Add Mate");
    form.submit();
}

function AddRoom() {
    CurrentAction.val("Add Room");
    form.submit();
}
function RemoveRoom(RoomId) {
    RemoveRoomId.val(RoomId);
    CurrentAction.val("Remove Room");
    form.submit();
}

function RemoveMate(MateId) {
    RemoveMateId.val(MateId);
    CurrentAction.val("Remove Mate");
    form.submit();
}
function AddMessage() {
    CurrentAction.val("Add Message");
    form.submit();
}