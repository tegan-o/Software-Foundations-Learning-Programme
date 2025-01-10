//
// For guidance on how to create routes see:
// https://prototype-kit.service.gov.uk/docs/create-routes
//

let Checking;

const govukPrototypeKit = require('govuk-prototype-kit')
const router = govukPrototypeKit.requests.setupRouter()

// Add your routes here

router.post('/parking-available-decide', function(req,res){
  Checking = false;

  var parkingAvailable = req.session.data['parkingAvailableAns']
  if(parkingAvailable == 'Y'){
    res.redirect('/parking-legal')
  }
  else if(parkingAvailable == 'N'){
    res.redirect('/ineligible')
  }
  else{
    res.redirect('/parking-available-error')
  }
})

router.post('/parking-legal-decide', function(req,res){

  var parkingLegal = req.session.data['parkingLegalAns']
  if(parkingLegal == 'Y'){
    res.redirect('/address-location')
  }
  else if(parkingLegal == 'N'){
    res.redirect('/ineligible')
  }
  else{
    res.redirect('/parking-legal-error')
  }
})

router.post('/vehicle-decide', function(req,res){

  var vehicle = req.session.data['vehicleAns']
  if(vehicle == 'Y'){
    res.redirect('/vehicle-vrn')
  }
  else if(vehicle == 'N'){
    res.redirect('/ineligible')
  }
  else{
    res.redirect('/vehicle-error')
  }
})

router.post('/address-location-decide', function(req,res){

  var AddressLoc = req.session.data['addressLocAns']
  if(AddressLoc == 'Y'){
    res.redirect('/address-input')
  }
  else if(AddressLoc == 'N'){
    res.redirect('/ineligible')
  }
  else{
    res.redirect('/address-location-error')
  }
})


router.post('/email-decide', function(req, res){

  var email = req.session.data['email']

  const emailRegex = /^[a-zA-Z0-9._%+\-']+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

  if (!email || !emailRegex.test(email.trim())) {
    res.redirect('/email-error');  // Redirect to error page if invalid
  } else {
    //valid email
    Checking = true;
    res.redirect('/check-answers');  // Replace with your next page
  }

})


router.post('/name-decide', function(req, res){

  var FullName = req.session.data['name']
  var valid

  if (!FullName || FullName.trim().length === 0 || FullName.trim().length > 70){
    valid = false
  }
  else{
    valid = true
  }

  if(Checking && valid){
    res.redirect('/check-answers')
  }
  else if (valid){
    res.redirect('/email')
  }
  else{
    //format is not valid
    res.redirect('name-error')
  }
})

router.post('/vehicle-vrn-decide', function(req,res){

  var Vrn = req.session.data['vehicleVRN']
  var valid

  if (!Vrn || Vrn.trim().length === 0 || Vrn.trim().length > 10){
    valid = false
  }
  else{
    valid = true
  }

  if(!valid){
    //if format is not valid
    res.redirect('/vehicle-vrn-error')
  }
  else {

    fetch("http://localhost:5082/api/Vrn", {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
    })
    .then(response => {
        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }
        //!
        if(Checking){
          //checking and valid
          res.redirect('/check-answers')
        }
        else{
          //valid and not checking answers
          res.redirect('/parking-available')
        }

      })
    .catch((error) => {
      console.error("Error:", error);
      // Redirect to an error page or handle error logic here
    });

    
  }
})

router.post('/address-input-decide', function(req,res){
  var line1 = req.session.data['addressLine1']
  var postcode = req.session.data['addressPostcode']

  var l1Valid = true;
  var postcodeValid = true;

  if (!line1 || line1.trim().length === 0 || line1.trim().length > 50){
    l1Valid = false
  }
  if (!postcode || postcode.trim().length === 0 || postcode.trim().length > 8){
    postcodeValid = false
  }

  //if invalid
  if(!postcodeValid && !l1Valid){
    res.redirect('/address-input-error3')
  }
  else if(!postcodeValid){
    res.redirect('address-input-error2')
  }
  else if(!l1Valid){
    res.redirect('address-input-error1')
  }
  else{
    //valid
    fetch("http://localhost:5082/api/Address", {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
    })
    .then(response => {
        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }
        //successful API call
        if(Checking){
          //checking and valid
          res.redirect('/check-answers')
        }
        else{
          //valid and not checking answers
          res.redirect('/address-confirm')
        }

      })
    .catch((error) => {
      console.error("Error:", error);
      // Redirect to an error page or handle error logic here
    });
  }


  //else if(Checking){
    //valid and checking
    //res.redirect('/check-answers')
  //}
  //else{
    //valid and not checking answers
    //res.redirect('/address-confirm')
  //}
})

router.post('/address-confirm-decide', function(req,res){
  if(Checking){
    res.redirect('/check-answers')
  }
  else{
    res.redirect('/eligible')
  }
})

router.post('/submit', function(req, res){
    var Application = {
    "name" : req.session.data['name'],
    "email" : req.session.data['email'],
    "vrn" : req.session.data['vehicleVRN'],
    "address" :  `${req.session.data['addressLine1']}, ${req.session.data['addressPostcode']}`}
 
    fetch("http://localhost:5082/api/Applicant", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(Application)
    })
      .then(response => {
        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }
        res.redirect('/confirmation')
        })
      .catch((error) => {
        console.error("Error:", error);
        // Redirect to an error page or handle error logic here
      });
    
  }
)