import axios from "axios";

const instance = axios.create({
  baseURL: "https://localhost:5001/api",
});

export async function getTasks() {
  let tasks = [];
  try {
    const response = await instance.get("/Todo");
    console.log(response);
    if (response.status === 200) {
      tasks = response.data;
      return { status: true, data: tasks };
    }
  } catch (error) {
    return { status: false, data: error.message };
  }
}

export async function getTask(id) {
  try {
    const response = await instance.get(`/Todo/${id}`);
    if (response.status === 200) {
      return { status: true, data: response.data };
    }
  } catch (error) {
    return { status: false, data: error.message };
  }
}
