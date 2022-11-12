#[macro_use] extern crate rocket;

#[get("/direct/<_identifier>")]
fn direct(_identifier: String) -> &'static str {
    "Hello, world!"
}

#[get("/transmux/<_identifier>")]
fn transmux(_identifier: String) -> &'static str {
    "Hello, world!"
}

#[launch]
fn rocket() -> _ {
    rocket::build().mount("/videos", routes![direct, transmux])
}
