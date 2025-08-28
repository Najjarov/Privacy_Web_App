let label2_v;
let label3_v;
let option_season;
let option_map;
let option_type;
let btn1;
let btn2;
let btn3;
let switch_00;
let switch_0;
let switch_1;
let switch_2;
var initImage;
let que_df;
let sel_x;
let sel_y;
let endzone_sel_index;

var Sp;
var Sp2;
var We;
var We2;
var Olymp2;
var selected_map;
var selected_val;
var selected_inval;
var val_sp_18;
var val_sp_16;
var val_we_18;
var val_we_16;
var val_olym_18;

var inval_sp_18;
var inval_sp_16;
var inval_we_18;
var inval_we_16;
var inval_olym_18;

let calFrom;
let calFrom2;

let startFlag = 0;
let dfQues;
let totQues;
let gameNum;
let gameTime;
let count;
let correct;
let finishFlag;
let imgWidth;
let imgHeight;
let table;
let df_sel;
let factorx;
let factory;
let uniqueValues
let checkboxContainer;
let checkboxes = [];
let disarr = [];
let indexarr = [];
let checkbox_all;
let cir5_r;
let cir4_r;
let circleX;
let circleY;

let circleX2;
let circleY2;
//let circleSize = 650;
let dragging = false;
let offsetX, offsetY;

let dragging2 = false;
let offsetX2, offsetY2;

function preload() {
  // Load the image in the preload function
  initImage = loadImage("/_public_html/Data/Imgs/SP.png");
  Sp = loadImage("/_public_html/Data/Imgs/SP.png");
  Sp2 = loadImage("/_public_html/Data/Imgs/SP2.png");
  We = loadImage("/_public_html/Data/Imgs/WE.png");
  We2 = loadImage("/_public_html/Data/Imgs/WE2.png");
  Olymp2 = loadImage("/_public_html/Data/Imgs/Olympus2.png");
  
  
  
  table = loadTable('serve_circle_csv.php', 'csv', 'header');
}
function setup() {
  
  createCanvas(1920, 1080);
  background(30);
  uniqueValues = [];
  //createCanvas(1366, 560);
  //stroke(50);
  totQues = 0;
  endzone_sel_index = -1;
  label2_v = "You played 0 games and got 0 correct. Your win rate is 0%.";
  label3_v = "0/0";
  textSize(32);
  
  fill(255);
  textStyle(BOLD); // Set text style to bold
  text("Predict The Zone",800, 25)
  textSize(24);
  text(label2_v, 500, 50);
  
  /*fill(30);
  noStroke();
  rect(width * 0.15, height * 0.07, width * 0.52, height * 0.05);
  fill(255);
  label2_v="You played 20 games and got 16 correct. Your win rate is 75.42%";
  text(label2_v, width * 0.15, height * 0.1);
  //text("You played 20 games and got 16 correct. Your win rate is 75.42%", width * 0.15, height * 0.1);*/
  
  text("0/0",1400 ,50)
  
  
  text("Season",1590 ,100);
  option_season = createSelect();
  option_season.position(1700, 80);
  option_season.option("16");
  option_season.option("18");
  option_season.changed(updateFol);
  option_season.size(100, 30);
  
  text("Map",1590 ,170);
  option_map = createSelect();
  option_map.position(1700, 150);
  // Add map options dynamically from your data source
  option_map.option("SP");
  option_map.option("WE");
  option_map.option("Olympus");
  option_map.changed(updateFol);
  option_map.size(100,30);
  
  // text("Type",1590 ,240);
  // option_type = createSelect();
  // option_type.position(1700, 220);
  // option_type.option("1 Circle");
  // option_type.option("2 Circles");
  // option_type.selected("2 Circles");
  // option_type.size(100,30);
  
  
  btn1 = createButton("Start");
  btn1.position(1650, 250);
  btn1.mousePressed(start);
  btn1.size(100,30);
  
  
  // btn2 = createButton("History");
  // btn2.position(1650, 670);
  // btn2.mousePressed(history);
  // btn2.size(100,30);
  
  // btn3 = createButton("Compare");
  // btn3.position(1650,320);
  // btn3.mousePressed(compare);
  // btn3.size(100,30);
  
  // btn4 = createButton("EndZones");
  // btn4.position(1650,390);
  // btn4.mousePressed(compare);
  // btn4.size(100,30);
  switch_00 = createCheckbox("  EndZones", false);
  switch_00.position(1650,390);
  //switch_00.changed(reconstruct);
  switch_00.size(200,30);
  switch_00.style('color', 'white');
  switch_00.style('background-color', 'rgb(30,30,30)');
  switch_00.style('font-size', '18px');
  
  btn5 = createButton("Export");
  btn5.position(1650,460);
  btn5.mousePressed(compare);
  btn5.size(100,30);
  
  
  text("From", 1600, 565);
  calFrom = createInput('', 'date');
  calFrom.position(1680,540);
  calFrom.size(120, 30);
  
  // Set initial date to today
  let today = new Date().toISOString().substr(0, 10);
  calFrom.attribute('value', "2015-02-10");
  
  
  text("To", 1610, 635);
  calFrom2 = createInput('', 'date');
  calFrom2.position(1680,610);
  calFrom2.size(120, 30);
  
  calFrom2.attribute('value', today);
  
  option_sol = createSelect();
  option_sol.position(1650, 700);
  option_sol.option("Deafult");
  option_sol.option("Solution1");
  option_sol.option("Solution2");
  option_sol.option("Solution3");
  //option_sol.changed(updateSol);
  option_sol.size(100, 30);
  
  // Add label
  textAlign(CENTER, CENTER);
  textSize(16);
  
  
  
  //initImage = loadImage("/_public_html/Data/Imgs/SP.png", () => {
    image(initImage, 450, 58);
  selected_map = Sp;
  circleX = 450+int(selected_map.width/2);
  circleY = 58+int(selected_map.height/2);
  circleX2 = 450+int(selected_map.width/2);
  circleY2 = 58+int(selected_map.height/2);
  cir5_r = 562;
    cir4_r = 300;
  disarr = [Infinity, Infinity, Infinity];
  indexarr = [-1, -1, -1];
  startFlag = 0;
  //print(initImage.width)
  //});
}

// function updateSol(){
//   image(selected_map,450,58);
//   noFill();
//   strokeWeight(1);
//   stroke(255)
//   circle(circleX, circleY, cir5_r);
//   circle(circleX2, circleY2, cir4_r);
  
//   if (startFlag){
//     stroke(0,0,255);
//   circle(int(df_sel.getString(indexarr[0], "cir0_x")), int(df_sel.getString(indexarr[0], "cir0_y")), 2*int(df_sel.getString(indexarr[0], "cir0_r")));
//     let sol_type = 
//   }
// }
function controls(){
  fill(30);
  noStroke();
  rect(0,0,1590,1080);
}
function draw() {
  //background(220);
  controls()
  image(selected_map,450,58);
  if(switch_00.checked()){
    //totQues = df_sel.length; 
  if (typeof df_sel !== 'undefined'){
  if(df_sel.getRowCount()>0){
    for (let i = 0; i < df_sel.getRowCount(); i++) {
  //creatQues();
  fill(0, 255, 0, 128);
  stroke(255);
  circle(450+int(df_sel.getString(i, "cir0_x")), 58+int(df_sel.getString(i, "cir0_y")), 10);    
  }
  // else{
  //   alert("no data for selected catogries");
  // }
    if(endzone_sel_index != -1 & switch_00.checked()){
      noFill();
      let time_stamp = df_sel.getString(endzone_sel_index, "TimeStamp");
      
      //print(time_stamp.substring(0, 11));
      rect(100,200,250,100);
      stroke(255);
      fill(255);
      textSize(32);
      text(time_stamp.substring(0, 11), 220, 250);
      fill(255,0,0);
      stroke(255,0,0);
      text("Endzone Date:", 200, 180);
      stroke(0,255,0);
      noFill();
      circle(450+int(df_sel.getString(endzone_sel_index, "cir0_x")), 58+ int(df_sel.getString(endzone_sel_index, "cir0_y")), 2*int(df_sel.getString(endzone_sel_index, "cir0_r")));
      
      circle(450+int(df_sel.getString(endzone_sel_index, "cir1_x")),58+ int(df_sel.getString(endzone_sel_index, "cir1_y")), 2*int(df_sel.getString(endzone_sel_index, "cir1_r")));
      
  circle(450+int(df_sel.getString(endzone_sel_index, "cir2_x")), 58+int(df_sel.getString(endzone_sel_index, "cir2_y")), 2*int(df_sel.getString(endzone_sel_index, "cir2_r")));    
      
   circle(450+int(df_sel.getString(endzone_sel_index, "cir3_x")), 58+int(df_sel.getString(endzone_sel_index, "cir3_y")), 2*int(df_sel.getString(endzone_sel_index, "cir3_r")));
      
  circle(450+int(df_sel.getString(endzone_sel_index, "cir4_x")), 58+int(df_sel.getString(endzone_sel_index, "cir4_y")), 2*int(df_sel.getString(endzone_sel_index, "cir4_r")));
    }
  }
}
  }
  
  else{
    endzone_sel_index = -1;
  noFill();
  strokeWeight(2);
  stroke(255)
  circle(circleX, circleY, cir5_r);
  circle(circleX2, circleY2, cir4_r);
  
  // Check if the mouse is over the circle
  let d = dist(mouseX, mouseY, circleX, circleY);
  let d2 = dist(mouseX, mouseY, circleX2, circleY2);
  //print(d-cir5_r/2)
  if (d<cir5_r/2+.01 & d>cir5_r/2-4) {
    cursor(HAND);
  }
  else if(d2<cir4_r/2+.01 & d2>cir4_r/2-4){
    cursor(HAND);
  }
  else {
    cursor(ARROW);
  }
  //}
  // if (d2<cir4_r/2-.01 & d2>cir4_r/2-2) {
  //   cursor(HAND);
  // } else {
  //   cursor(ARROW);
  // }
  if (typeof df_sel === 'undefined'){
    return;
  }
  if (startFlag){
    stroke(0,255,0);
    
stroke(0,0,255);
    let sol_type = option_sol.value();
    if(sol_type==="Deafult"){
  circle(450+int(df_sel.getString(indexarr[0], "cir0_x")), 58+int(df_sel.getString(indexarr[0], "cir0_y")), 2*int(df_sel.getString(indexarr[0], "cir0_r")));
    }
    
    
    else if (sol_type==="Solution1"){
      circle(450+int(df_sel.getString(indexarr[0], "cir0_x")), 58+int(df_sel.getString(indexarr[0], "cir0_y")), 2*int(df_sel.getString(indexarr[0], "cir0_r")));
      
      circle(450+int(df_sel.getString(indexarr[0], "cir1_x")), 58+int(df_sel.getString(indexarr[0], "cir1_y")), 2*int(df_sel.getString(indexarr[0], "cir1_r")));
      
  circle(450+int(df_sel.getString(indexarr[0], "cir2_x")), 58+int(df_sel.getString(indexarr[0], "cir2_y")), 2*int(df_sel.getString(indexarr[0], "cir2_r")));    
      
   circle(450+int(df_sel.getString(indexarr[0], "cir3_x")), 58+int(df_sel.getString(indexarr[0], "cir3_y")), 2*int(df_sel.getString(indexarr[0], "cir3_r")));
      
  circle(450+int(df_sel.getString(indexarr[0], "cir4_x")), 58+int(df_sel.getString(indexarr[0], "cir4_y")), 2*int(df_sel.getString(indexarr[0], "cir4_r")));
      
    }
    
    else if (sol_type==="Solution2"){
      circle(450+int(df_sel.getString(indexarr[1], "cir0_x")), 58+int(df_sel.getString(indexarr[1], "cir0_y")), 2*int(df_sel.getString(indexarr[1], "cir0_r")));
      
      circle(450+int(df_sel.getString(indexarr[1], "cir1_x")),58+ int(df_sel.getString(indexarr[1], "cir1_y")), 2*int(df_sel.getString(indexarr[1], "cir1_r")));
      
  circle(450+int(df_sel.getString(indexarr[1], "cir2_x")),58+ int(df_sel.getString(indexarr[1], "cir2_y")), 2*int(df_sel.getString(indexarr[1], "cir2_r")));    
      
   circle(450+int(df_sel.getString(indexarr[1], "cir3_x")), 58+int(df_sel.getString(indexarr[1], "cir3_y")), 2*int(df_sel.getString(indexarr[1], "cir3_r")));
      
  circle(450+int(df_sel.getString(indexarr[1], "cir4_x")),58+ int(df_sel.getString(indexarr[1], "cir4_y")), 2*int(df_sel.getString(indexarr[1], "cir4_r")));
      
    }
    
    else if (sol_type==="Solution3"){
      circle(450+int(df_sel.getString(indexarr[2], "cir0_x")), 58+int(df_sel.getString(indexarr[2], "cir0_y")), 2*int(df_sel.getString(indexarr[2], "cir0_r")));
      
      circle(450+int(df_sel.getString(indexarr[2], "cir1_x")), 58+int(df_sel.getString(indexarr[2], "cir1_y")), 2*int(df_sel.getString(indexarr[2], "cir1_r")));
      
  circle(450+int(df_sel.getString(indexarr[2], "cir2_x")),58+ int(df_sel.getString(indexarr[2], "cir2_y")), 2*int(df_sel.getString(indexarr[2], "cir2_r")));    
      
   circle(450+int(df_sel.getString(indexarr[2], "cir3_x")),58+ int(df_sel.getString(indexarr[2], "cir3_y")), 2*int(df_sel.getString(indexarr[2], "cir3_r")));
      
  circle(450+int(df_sel.getString(indexarr[2], "cir4_x")), 58+int(df_sel.getString(indexarr[2], "cir4_y")), 2*int(df_sel.getString(indexarr[2], "cir4_r")));
      
    }
  }
  
  }
}

function mousePressed() {
  // Check if the mouse is pressed inside the circle
  let d = dist(mouseX, mouseY, circleX, circleY);
  let d2 = dist(mouseX, mouseY, circleX2, circleY2);
  
  if (d<cir5_r/2+.01 & d>cir5_r/2-4) {
    dragging = true;
    offsetX = circleX - mouseX;
    offsetY = circleY - mouseY;
  }
  
  if (d2<cir4_r/2+.01 & d2>cir4_r/2-4) {
    dragging2 = true;
    offsetX2 = circleX2 - mouseX;
    offsetY2 = circleY2 - mouseY;
  }
}

function mouseDragged() {
  if (dragging) {
    circleX = mouseX + offsetX;
    circleY = mouseY + offsetY;
  }
  
  if (dragging2) {
    circleX2 = mouseX + offsetX2;
    circleY2 = mouseY + offsetY2;
  }
  if(circleX>1300){
    circleX = 1300;
  }
  if(circleX2>1400){
    circleX2 = 1400;
  }
  //print(circleX,circleY, circleX2,circleY2);
}

function mouseReleased() {
  dragging = false;
  dragging2 = false;
  
  if(switch_00.checked()){
    //totQues = df_sel.length; 
  if (typeof df_sel !== 'undefined'){
  if(df_sel.getRowCount()>0){
    for (let i = 0; i < df_sel.getRowCount(); i++) {
      let dis_end = dist(mouseX-450, mouseY-58, int(df_sel.getString(i, "cir0_x")), int(df_sel.getString(i, "cir0_y")));
      //print(dis_end);
      if(dis_end<10){
        endzone_sel_index = i;
        break;
      }
      if(i>=df_sel.getRowCount()){
        endzone_sel_index = -1;
      }
    }
  }
    //print(endzone_sel_index);
  }
  }
}
function start(){
  option_sol.selected('Deafult');
  let map = option_map.value();
  let season = option_season.value();
  
  disarr = [Infinity, Infinity, Infinity];
  indexarr = [-1, -1, -1];
  
  df_sel = filterData(table, 'map', map, 'season', season);
  //print(df_sel.length); 
  if(df_sel.getRowCount()>0){
  //creatQues();
  }
  else{
    alert("no data for selected catogries");
    return;
  }
  
  df_sel.addColumn('dist');
  for (let i = 0; i < df_sel.getRowCount(); i++) {  
    //let que_df = df_sel[i];
    let dis = dist(int(df_sel.getString(i, "cir4_x")), int(df_sel.getString(i, "cir4_y")), circleX-450, circleY-58) + dist(int(df_sel.getString(i, "cir3_x")), int(df_sel.getString(i, "cir3_y")), circleX2-450, circleY2-58);
    
    df_sel.setNum(i, 'dist', dis);
    
    if(dis<disarr[2]){
      if(dis<disarr[0]){
        disarr[2] = disarr[1];
        disarr[1] = disarr[0];
        disarr[0] = dis;
        
        indexarr[2] = indexarr[1];
        indexarr[1] = indexarr[0];
        indexarr[0] = i;
      }
      else if(dis<disarr[1]){
              disarr[2] = disarr[1];
              disarr[1] = dis;
        
              indexarr[2] = indexarr[1];
              indexarr[1] = i;
              }
      else{
        disarr[2] = dis;
        indexarr[2] = i;
      }
    }
  }
  //print("start");
  startFlag = 1;
  //df_sel.sortRows(compareRows);
  // stroke(0,0,255);
  // circle(int(df_sel.getString(indexarr[0], "cir0_x")), int(df_sel.getString(indexarr[0], "cir0_y")), 2*int(df_sel.getString(indexarr[0], "cir0_r")));
  //print("Sorted Table:");
  //printTable(df_sel);
  // print(disarr);
  // print(indexarr);
  // print(circleX, circleY);
  // print(circleX2, circleY2);
  //print(int(df_sel.getString(indexarr[0], "cir0_x")), int(df_sel.getString(indexarr[0], "cir0_y")), 2*int(df_sel.getString(indexarr[0], "cir0_r")));
}

// function printTable(table) {
//   for (let i = 0; i < table.getRowCount(); i++) {
//     let row = table.getRow(i);
//     let rowData = [];
//     for (let j = 0; j < table.columns.length; j++) {
//       rowData.push(row.get(j));
//     }
//     print(rowData);
//   }
// }
function compareRows(a, b) {
  let disA = parseFloat(a.getNum('dist'));
  let disB = parseFloat(b.getNum('dist'));
  return disA - disB;
}
function filterData(data, columnName, filterValue, columnName2, filterValue2) {
      let filteredRows = [];
      let filteredFolders = [];
  let selectedDate = calFrom.value();
  let selectedDate2 = calFrom2.value();
  let filteredTable = createTableWithSameColumns(table); 
    
      for (let i = 0; i < data.getRowCount(); i++) {
        let value = data.getString(i, columnName);
        let value2 = data.getString(i, columnName2);
        let value3 = data.getString(i, "folder");
        let value4 = data.getString(i, "TimeStamp");
        value4 = value4.replace(/_/g, "-");
        value4 = value4.slice(0,10)
        //print("hhh",value4.slice(0,10), selectedDate, selectedDate2, value4>=selectedDate);
        //print(value3);
        if (value === filterValue & value2===filterValue2 & value4>=selectedDate & value4<=selectedDate2 &(filteredFolders.length===0 | filteredFolders.includes(value3))) {
          //filteredRows.push(data.getRow(i));
          let newRow = filteredTable.addRow();
          let currentRow = data.getRow(i);
          //newRow.set()
          newRow.obj = Object.assign({}, currentRow.obj);
        }
      }
     // print(filteredRows.length);
      // Return a new p5.Table with the filtered rows
      return filteredTable;//new p5.Table(filteredRows);
    }


function createTableWithSameColumns(existingTable) {
  
    // Create a new table
    let newTable = new p5.Table();

    // Copy column names from the existing table
    let columnNames = existingTable.columns;
    
    // Add columns to the new table
    for (let i = 0; i < columnNames.length; i++) {
      newTable.addColumn(columnNames[i]);
    }

    return newTable;
}

function updateFol() {
  fill(30);
  noStroke();
  rect(450, 58, 1020, 1025);
  fill(255);
  strokeWeight(2);
  stroke(255)
  let map = option_map.value();
  let season = option_season.value();
  
  if (map === "") {
    alert("Please select map and folders");
    
    return;
  }

  // Load images based on map and season
  //let imagePath;
  df_sel = filterData(table, 'map', map, 'season', season);
  if (typeof df_sel === 'undefined'){
    return;
  }
  if (map === "SP" && season === "16") {
    //imagePath = "/_public_html/Data/Imgs/SP.png"; // Adjust the actual paths accordingly
    image(Sp, 450, 58);
    imgWidth = Sp.width;
    imgHeight = Sp.height;
    selected_map = Sp;
    cir5_r = 562;
    cir4_r = 300;
    
  } else if (map === "SP" && season === "18") {
    //imagePath = "/_public_html/Data/Imgs/SP2.png";
    image(Sp2, 450, 58);
    imgWidth = Sp2.width;
    imgHeight = Sp2.height;
    selected_map = Sp2;
    cir5_r = 612;
    cir4_r = 300;
    
  } else if (map === "WE" && season === "16") {
    //imagePath = "/_public_html/Data/Imgs/WE.png";
    image(We, 450, 58);
    imgWidth = We.width;
    imgHeight = We.height;
    selected_map = We;
    cir5_r = 545;
    cir4_r = 297;
  } else if (map === "WE" && season === "18") {
    //imagePath = "/_public_html/Data/Imgs/WE2.png";
    image(We2, 450, 58);
    imgWidth = We2.width;
    imgHeight = We2.height;
    selected_map = We2;
    cir5_r = 604;
    cir4_r = 297;
    
  } else if (map === "Olympus" && season === "18") {
    //imagePath = "/_public_html/Data/Imgs/Olympus2.png";
    image(Olymp2, 450, 58);
    imgWidth = Olymp2.width;
    imgHeight = Olymp2.height;
    selected_map = Olymp2;
    cir5_r = 500;
    cir4_r = 300;
    
  } else if (map === "Olympus" && season === "16") {
    alert("No Olympus map in season 16");
    return;
  } else {
    alert("Please select map and folder");
    return;
  }
  factorx = width * 0.74/imgWidth;
  factory = height * 0.88/imgHeight;
  
  noFill();
  stroke(255);
  strokeWeight(2);
  circleX = 450+int(imgWidth/2);
  circleY = 58+int(imgHeight/2);
  circle(450+int(imgWidth/2),58+int(imgHeight/2),cir5_r);
  circle(450+int(imgWidth/2),58+int(imgHeight/2),cir4_r);
}

function compare() {
  img = get(450, 58, 1020, 1025);
  
  // Save the image as a PNG file
  img.save('endzone_image.png');
}