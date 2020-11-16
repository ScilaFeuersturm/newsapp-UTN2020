import instance, { setClientToken } from "./configure";

const resource = '/users';

export async function login(email, password) {
  try {
    const response = await instance.post(`${resource}/login`, { email, password });
    if (response.status === 200) {
      localStorage.setItem('token', response.data)
      setClientToken(response.data);
      return { status: true, data: response.data };
    }
  } catch (error) {
    return { status: false, data: error.message };
  }
}

export async function register(email, password) {
  try {
    const response = await instance.post(`${resource}/register`, { email, password });
    if (response.status === 200) {
      return { status: true, data: response.data };
    }
  } catch (error) {
    return { status: false, data: error.message };
  }
}

export function logout() {
  localStorage.removeItem('token');
}

export function isAuthenticated() {
  return !!localStorage.getItem("token");
}