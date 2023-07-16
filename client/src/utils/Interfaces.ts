
export interface IClient {
    clientId : number,
    firstName : string,
    lastName : string,
    email : string
}

export interface IClientDetails {
    clientId: number,
    firstName: string,
    lastName: string,
    email: string,
    profile: {
      clientId: number,
      age: number,
      gender: string,
      maritalStatus: string
    },
    address: {
      clientId: number,
      country: string,
      streetAddress: string,
      city: string,
      zip: number
    }
}